using Defender.Assets;
using Defender.Data.Static;
using Defender.Factory;
using Defender.Logic;
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

        public void Exit() { }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>(MAIN_SCENE);

        private void RegisterService()
        {
            RegisterAssetProvider();
            RegisterStaticData();
            RegisterProgressService();
            RegisterGameFactory();
            RegisterSaveLoadService();
        }


        private void RegisterAssetProvider()
        {
            var assetProvider = new AssetsProvider();
            _services.RegisterSingle<IAssetsProvider>(assetProvider);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadMonsters();
            _services.RegisterSingle(staticData);
        }
        
        private void RegisterProgressService() 
        {
            _services.RegisterSingle<IProgressService>(new ProgressService());
        }
        
        private void RegisterGameFactory()
        {
            _services.RegisterSingle<IGameFactory>(
                            new GameFactory(
                            _services.Single<IAssetsProvider>(),
                            _services.Single<IStaticDataService>(),
                            _services.Single<IRandomService>(),
                            _services.Single<IProgressService>()));
        }

        private void RegisterSaveLoadService() 
        {
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IProgressService>(),
                _services.Single<IGameFactory>()));
        }
    }
}