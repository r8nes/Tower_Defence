﻿using Defender.Data.Static;
using Defender.Entity;
using Defender.Factory;
using Defender.Service;
using Defender.System;
using Defender.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IProgressService _progressService;

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingUI _loadingUI;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI, IGameFactory gameFactory, IStaticDataService dataService, IProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingUI = loadingUI;
            _gameFactory = gameFactory;
            _dataService = dataService;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingUI.ShowLoader();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingUI.HideLoader();
        }

        private void OnLoaded()
        {
            InitGameWrold();
            //InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }

        #region Initials

        private void InitGameWrold()
        {
            LevelStaticData levelData = GetLevelStaticData();

            InitSpawners(levelData);

            GameObject player = InitPlayer(levelData);

            InitHud(player);
        }

        private GameObject InitHud(GameObject player)
        {
            GameObject hud = _gameFactory.CreateHud();

            if (hud.TryGetComponent(out ActorUI actor))
            {
                actor.Construct(player.GetComponent<PlayerHealth>());
            }

            return hud;
        }

        private void InitSpawners(LevelStaticData levelData)
        {
            foreach (EnemySpawnerData spawnerData in levelData.EnemySpawner)
                _gameFactory.CreateSpawner(
                    spawnerData.Position,
                    spawnerData.Id,
                    spawnerData.MonsterTypeId,
                    spawnerData.WaveCount,
                    spawnerData.WaveDelay);
        }

        private GameObject InitPlayer(LevelStaticData levelData) => _gameFactory.CreatePlayer(levelData.InitialHeroPosition);

        #endregion

        private LevelStaticData GetLevelStaticData()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _dataService.ForLevel(sceneKey);

            return levelData;
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReader)
                reader.LoadProgress(_progressService.Progress);
        }
    }
}