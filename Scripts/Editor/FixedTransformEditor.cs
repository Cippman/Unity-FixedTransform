/*
 *  Author: Alessandro Salani (Cippman)
 */
using UnityEditor;
using UnityEngine;
using CippSharp;

namespace CippSharpEditor
{
    [CustomEditor(typeof(AFixedTransform), true)]
    public class FixedTransformEditor : Editor
    {
        protected AFixedTransform aFixedTransform;
        protected Transform transform;
        
        protected virtual void OnEnable()
        {
            aFixedTransform = ((AFixedTransform) target);
            transform = aFixedTransform.transform;
        }

        public override void OnInspectorGUI()
        {
            bool guiEnabled = GUI.enabled;
            GUI.enabled = false;
            aFixedTransform.showChildrenLocalPositionInfo = EditorGUILayout.Foldout(aFixedTransform.showChildrenLocalPositionInfo, "Children");
            if (aFixedTransform.showChildrenLocalPositionInfo)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    EditorGUILayout.Vector3Field(child.name, child.localPosition);
                }
            }
            GUI.enabled = guiEnabled;
        }
    }
}