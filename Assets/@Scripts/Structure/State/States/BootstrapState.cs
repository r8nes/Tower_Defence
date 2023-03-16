using Defender.Structure;

namespace Defender.State
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

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
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
        }

        private void RegisterService()
        {
            //TODO
        }

        public void Exit()
        {
        }
    }
}