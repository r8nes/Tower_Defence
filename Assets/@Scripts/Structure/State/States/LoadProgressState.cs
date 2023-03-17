using Defender.Data;
using Defender.Service;

namespace Defender.State
{
    public class LoadProgressState : IState
    {
        private const string START_SCENE = "Main";

        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(START_SCENE);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress =
            _saveLoadService.LoadProgress()
            ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            progress.PlayerDamageData.Damage = 3f;
            progress.PlayerDamageData.DamageRadius = 0.5f;

            progress.HealthData.MaxHP = 20f;
            progress.HealthData.ResetCurrentHP();

            return progress;
        }
    }
}