using System.Collections.Generic;
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

        private List<WindowBase> OpenWindows = new List<WindowBase>(2);

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
            foreach (WindowBase openWindow in OpenWindows)
            {
                WindowId id = openWindow.GetId();
                if (id == windowId) return;
            }

            WindowConfigData config = _staticData.ForWindow(windowId);
            WindowBase window = UnityEngine.Object.Instantiate(config.Prefab, _uiRoot);

            window.Construct(windowId, _progressService, _stateMachine);
            window.WindowClosed += OnWindowClosed;

            OpenWindows.Add(window);
        }

        private void OnWindowClosed(WindowId id) 
        {
            for (int i = 0; i < OpenWindows.Count; i++)
            {
                if (OpenWindows[i].GetId() == id)
                {
                    OpenWindows[i].WindowClosed -= OnWindowClosed;
                    OpenWindows.Remove(OpenWindows[i]);
                }
            }
        }
    }
}