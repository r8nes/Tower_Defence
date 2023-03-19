using System;
using Defender.UI;

namespace Defender.Service
{
    [Serializable]
    public class WindowConfigData
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}