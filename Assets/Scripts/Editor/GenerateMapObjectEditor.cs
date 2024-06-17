using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Runner.CustomEdit
{
    [CustomEditor(typeof(GenerateMapObject))]
    public class GenerateMapObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GenerateMapObject generator = target as GenerateMapObject;

            base.OnInspectorGUI();

            if (GUILayout.Button("Fill SpawnPos"))
            {
                GameObject[]positionsTab = GameObject.FindGameObjectsWithTag("SpawnPosition");   
                generator.SetPositionList(positionsTab);
            }
        }
    }
}
