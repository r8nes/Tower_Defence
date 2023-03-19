using System;
using Defender.Data;
using Defender.Service;
using Defender.State;
using UnityEngine;
using UnityEngine.UI;

namespace Defender.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;

        protected WindowId _windowId;

        protected IProgressService _progressService;
        protected IGameStateMachine _stateMachine;

        public event Action<WindowId> WindowClosed;

        protected PlayerProgress Progress => _progressService.Progress;

        public void Construct(WindowId Id, IProgressService progressService, IGameStateMachine stateMachine)
        {
            _windowId = Id;
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public WindowId GetId() 
        {
            return _windowId;
        }

        private void Awake() => OnAwake();

        private void Start()
        {
            Initialize();
            SubScribeUpdates();
        }
        
        private void OnDestroy() => CleanUp();
        protected virtual void OnAwake()
        {

            CloseButton.onClick.AddListener(() => Destroy(gameObject));
        }

        protected virtual void Initialize() { }
        protected virtual void SubScribeUpdates() { }
        protected virtual void CleanUp() 
        {
            WindowClosed?.Invoke(_windowId);
        }
    }
}