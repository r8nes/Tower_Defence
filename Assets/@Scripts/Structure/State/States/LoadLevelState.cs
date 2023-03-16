using Defender.Structure;

namespace Defender.State
{
    public class LoadLevelState : IState
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

        public void Enter() {}

        public void Exit() {}
    }
}