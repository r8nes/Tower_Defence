using Defender.Assets;
using UnityEngine;

namespace Defender.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assets;

        public GameFactory(IAssetsProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(GameObject initialPoint) =>
            _assets.Instantiate(AssetsPath.PLAYER_PATH, point: initialPoint.transform.position);

        public void CreateHud() => _assets.Instantiate(AssetsPath.GLOBAL_HUD_PATH);
    }
}