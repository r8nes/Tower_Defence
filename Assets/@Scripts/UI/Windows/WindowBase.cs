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

        protected IProgressService _progressService;
        protected IGameStateMachine _stateMachine;
        protected PlayerProgress Progress => _progressService.Progress;

        public void Construct(IProgressService progressService, IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        private void Awake() => OnAwake();

        private void Start()
        {
            Initialize();
            SubScribeUpdates();
        }
        private void OnDestroy() => CleanUp();
        protected virtual void OnAwake() => CloseButton.onClick.AddListener(() => Destroy(gameObject));
        protected virtual void Initialize() { }
        protected virtual void SubScribeUpdates() { }
        protected virtual void CleanUp() { }
    }
}