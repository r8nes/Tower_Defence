using Defender.State;
using Defender.UI;
using UnityEngine;

namespace Defender.Service
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_PATH = "UI/UIRoot";

        private readonly IAssetsProvider _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private readonly IGameStateMachine _stateMachine;

        private Transform _uiRoot;

        public UIFactory(IAssetsProvider asset, IStaticDataService staticData, IProgressService progressService, IGameStateMachine stateMachine)
        {
            _asset = asset;
            _staticData = staticData;
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void CreateUIRoot()
        {
            GameObject root = _asset.Instantiate(UI_ROOT_PATH);
            _uiRoot = root.transform;
        }

        public void CreateWindowById(WindowId windowId)
        {
            WindowConfigData config = _staticData.ForWindow(windowId);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
            window.Construct(_progressService, _stateMachine);
        }
    }
}
