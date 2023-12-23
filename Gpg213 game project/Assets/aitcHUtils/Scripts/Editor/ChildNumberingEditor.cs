using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace aitcHUtils
{
    [CustomEditor(typeof(ChildNumbering))]
    public class ChildNumberingEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ChildNumbering myScript = (ChildNumbering)target;
            if (GUILayout.Button("Rename Children"))
            {
                myScript.RenameChildren();
            }
        }
    }
}
