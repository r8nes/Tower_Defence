using Defender.System;

namespace Defender.State
{
    public class BootstrapState : IState
    {
        private const string INITIAL_SCENE = "Initial";
        private const string MAIN_SCENE = "Main";

        private SceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterService();
            _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>(MAIN_SCENE);

        private void RegisterService()
        {
            //TODO
        }

        public void Exit()
        {
        }
    }
}