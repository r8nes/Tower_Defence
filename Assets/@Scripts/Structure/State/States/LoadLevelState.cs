using Defender.Data.Static;
using Defender.Factory;
using Defender.Service;
using Defender.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingUI _loadingUI;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI, IGameFactory gameFactory, IStaticDataService dataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingUI = loadingUI;
            _gameFactory = gameFactory;
            _dataService = dataService;
        }

        public void Enter(string sceneName)
        {
            _loadingUI.ShowLoader();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingUI.HideLoader();
        }

        private void OnLoaded()
        {
            InitGameWrold();

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

        private void InitHud(GameObject player)
        {
            _gameFactory.CreateHud();
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
    }
}