using System;
using UnityEngine;

namespace TopDownGame.Structure
{
    public class BootstrapState : IState
    {
        private GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
            RegisterService();
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