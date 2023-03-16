using Defender.System;

namespace Defender.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        //HACK
        public void Enter(string sceneName) => _sceneLoader.Load(sceneName);

        public void Enter() { }

        public void Exit() { }
    }
}