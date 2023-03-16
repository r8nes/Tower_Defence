using Defender.Factory;
using Defender.System;
using UnityEngine;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string INITIAL_POINT = "InitialPoint";

        private readonly IGameFactory _gameFactory;
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingUI _loadingUI;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingUI = loadingUI;
            _gameFactory = gameFactory;
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
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindGameObjectWithTag(INITIAL_POINT));

            _gameFactory.CreateHud();
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}