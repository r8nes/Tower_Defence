using Defender.State;
using UnityEngine;

namespace Defender.System
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        public LoadingUI LoadingUI;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(LoadingUI));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
