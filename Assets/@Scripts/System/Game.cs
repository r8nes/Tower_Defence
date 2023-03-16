using Defender.Service;
using Defender.State;

namespace Defender.System
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingUI loadingUi)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingUi, AllServices.Container);
        }
    }
}
