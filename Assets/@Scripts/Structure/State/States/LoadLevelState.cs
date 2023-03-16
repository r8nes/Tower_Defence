using Defender.Data.Static;
using Defender.Factory;
using Defender.System;
using UnityEngine;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string INITIAL_POINT = "InitialPoint";

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

        private void InitGameWrold()
        {
            _gameFactory.CreatePlayer(GameObject.FindGameObjectWithTag(INITIAL_POINT));
            _gameFactory.CreateHud();
        }
    }
}