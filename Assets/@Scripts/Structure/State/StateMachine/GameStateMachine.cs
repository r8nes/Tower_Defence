using System;
using System.Collections.Generic;
using Defender.Structure;

namespace Defender.State
{
    public class GameStateMachine : IGameStateMachine
    {
        private IExitableState _activeState;
        private readonly Dictionary<Type, IExitableState> _states;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            IState state = GetState<TState>();
            _activeState = state;
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            _activeState?.Exit();
            IPayLoadState<TPayLoad> state = (IPayLoadState<TPayLoad>)GetState<TState>();
            _activeState = state;
            state.Enter(payLoad);
        }

        private IState GetState<TState>() where TState : class, IExitableState => (IState)(_states[typeof(TState)] as TState);
    }
}