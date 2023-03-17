using System.Linq;
using Defender.Data.Static;
using Defender.Logic;
using Defender.System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string INITIAL_POINT = "InitialPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Setup Settings"))
            {
                levelData.EnemySpawner = FindObjectsOfType<SpawnMarker>().Select(x => new EnemySpawnerData(x.GetComponent<UniqueId>().Id, x.MonsterTypeId, x.transform.position, x.WaveCount, x.WaveDelay)).ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;

                levelData.InitialHeroPosition = GameObject.FindWithTag(INITIAL_POINT).transform.position;
            }

            EditorUtility.SetDirty(target);
        }
    }
}