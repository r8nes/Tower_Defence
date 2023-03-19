using System.Collections.Generic;
using UnityEngine;

namespace Defender.Service
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/Window")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfigData> Configs;
    }
}