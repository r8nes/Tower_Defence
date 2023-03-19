using System.Collections.Generic;
using Defender.Data.Static;
using UnityEngine;

namespace Defender.Service
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/Window")]
    public class WindowsStaticData : BaseStaticData
    {
        public List<WindowConfigData> Configs;
    }
}