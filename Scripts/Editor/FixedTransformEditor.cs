using UnityEditor;
using UnityEngine;
using CippSharp;

namespace CippSharpEditor
{
    [CustomEditor(typeof(AFixedTransform), true)]
    public class FixedTransformEditor : Editor
    {
        protected Transform transform;
        
        protected virtual void OnEnable()
        {
            transform = ((AFixedTransform) target).transform;
        }

        public override void OnInspectorGUI()
        {
            bool guiEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUILayout.LabelField("Children", EditorStyles.boldLabel);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                EditorGUILayout.Vector3Field(child.name, child.localPosition);
            }
            GUI.enabled = guiEnabled;
        }
    }
}