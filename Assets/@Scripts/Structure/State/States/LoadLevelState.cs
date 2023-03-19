using Defender.Data.Static;
using Defender.Entity;
using Defender.Factory;
using Defender.Logic;
using Defender.Service;
using Defender.System;
using Defender.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IProgressService _progressService;

        private readonly LoadingUI _loadingUI;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI,
            IGameFactory gameFactory, IStaticDataService dataService, IProgressService progressService, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _loadingUI = loadingUI;
            _dataService = dataService;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
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
            InitUIRoot();
            InitGameWrold();
            //InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private LevelStaticData GetLevelStaticData()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _dataService.ForLevel(sceneKey);

            return levelData;
        }

        #region Initials
        private void InitUIRoot() => _uiFactory.CreateUIRoot();

        private void InitGameWrold()
        {
            LevelStaticData levelData = GetLevelStaticData();

            InitSpawners(levelData);

            GameObject player = InitPlayer(levelData);

            InitHud(player);
        }

        private void InitSpawners(LevelStaticData levelData)
        {
            var spawn = _gameFactory.CreateSpawner();

            foreach (SpawnerTransform spawnMarker in levelData.SpawnerTransform)
                spawn.AddSpawnMarker(spawnMarker);
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

        private GameObject InitPlayer(LevelStaticData levelData) => _gameFactory.CreatePlayer(levelData.InitialHeroPosition);

        #endregion

        #region NoUsed

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReader)
                reader.LoadProgress(_progressService.Progress);
        }

        #endregion
    }
}