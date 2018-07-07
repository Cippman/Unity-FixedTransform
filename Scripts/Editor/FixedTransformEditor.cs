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
        protected int localIdentfierInFile;
        protected AFixedTransform aFixedTransform;
        protected Transform transform;
        
        protected virtual void OnEnable()
        {
            aFixedTransform = ((AFixedTransform) target);
            localIdentfierInFile = EditorGUILayoutUtilities.GetLocalIdentfierInFile(aFixedTransform);
            transform = aFixedTransform.transform;
        }

        public override void OnInspectorGUI()
        {
            DrawAFixedTransformData();
            DrawAFixedTransformInspector();
        }

        protected void DrawAFixedTransformData()
        {
            EditorGUILayoutUtilities.DrawObjectData(serializedObject, localIdentfierInFile);
        }

        protected void DrawAFixedTransformInspector()
        {
            serializedObject.Update();
            EditorGUILayoutUtilities.DrawHeader("Infos:");
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
            serializedObject.ApplyModifiedProperties();
        }
    }
}