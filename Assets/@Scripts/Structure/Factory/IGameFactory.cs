using Defender.Service;
using UnityEngine;

namespace Defender.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject initialPoint);
        void CreateHud();
    }
}