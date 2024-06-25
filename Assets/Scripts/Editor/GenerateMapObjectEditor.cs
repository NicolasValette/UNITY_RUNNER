using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

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
                Func<GameObject, GameObject, int> sortObj = (x, y) =>
                {
                    if (x.name.Length < y.name.Length)
                        return -1;
                    else if (x.name.Length > y.name.Length)
                        return 1;
                    else
                        x.name.CompareTo(y.name);
                    return 0;
                };

                List<GameObject> list = positionsTab.ToList();
                list.Sort(new Comparison<GameObject>(sortObj));
                generator.SetPositionList(positionsTab.ToList().OrderBy(x => x.name).ToArray());
            }
        }
    }
}
