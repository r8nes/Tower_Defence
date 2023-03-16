using Defender.Assets;
using Defender.Factory;
using Defender.Service;
using Defender.System;

namespace Defender.State
{
    public class BootstrapState : IState
    {
        private const string INITIAL_SCENE = "Initial";
        private const string MAIN_SCENE = "Main";

        private readonly AllServices _services;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterService();
        }

        public void Enter() => _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);

        public void Exit() {}

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>(MAIN_SCENE);

        private void RegisterService()
        {
            _services.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetsProvider>()));
        }
    }
}