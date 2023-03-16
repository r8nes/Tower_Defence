using System;
using Defender.Assets;
using Defender.System;
using UnityEngine;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string INITIAL_POINT = "InitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingUI _loadingUI;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingUI = loadingUI;
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
            var initialPoint = GameObject.FindGameObjectWithTag(INITIAL_POINT);

            GameObject player = Instantiate(AssetsPath.PLAYER_PATH, point: initialPoint.transform.position);
            _gameStateMachine.Enter<GameLoopState>();
        }

        /// <summary>
        ///  Instantiate object without position.
        /// </summary>
        /// <param name="path">Asset path direction</param>
        /// <param name="point"></param>
        /// <returns>New object</returns>
        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab);
        }

        /// <summary>
        ///  Instantiate object with given position.
        /// </summary>
        /// <param name="path">Asset path direction</param>
        /// <param name="point">Current location</param>
        /// <returns>New object</returns>
        private static GameObject Instantiate(string path, Vector2 point)
        {
            var prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab, point, Quaternion.identity);
        }

    }
}