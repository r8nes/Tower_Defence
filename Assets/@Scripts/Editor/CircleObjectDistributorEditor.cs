using Defender.Utility;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CircleObjectDistributor))]
    public class CircleObjectDistributorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Distribute Objects"))
            {
                CircleObjectDistributor circleDistributor = (CircleObjectDistributor)target;
                circleDistributor.UpdateObjectPositions();
            }
        }
    }
}