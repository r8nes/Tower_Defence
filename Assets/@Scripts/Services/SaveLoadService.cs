using Defender.Data;
using Defender.Factory;
using UnityEngine;

namespace Defender.Service
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        private readonly IProgressService _progress;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IProgressService progress, IGameFactory gameFactory)
        {
            _progress = progress;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress writer in _gameFactory.ProgressWriters)
                writer.UpdateProgress(_progress.Progress);

            PlayerPrefs.SetString(PROGRESS_KEY, _progress.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(PROGRESS_KEY)?
                .ToDeserialized<PlayerProgress>();

        public void PrintPlayerPrefs()
        {
            Debug.Log(PlayerPrefs.HasKey(PROGRESS_KEY));
        }
    }
}