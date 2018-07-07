/*
 *  Author: Alessandro Salani (Cippman)
 */
using UnityEditor;
using UnityEngine;
using CippSharp;

namespace CippSharpEditor
{
    [CustomEditor(typeof(AFixedTransform), true)]
    public class AFixedTransformEditor : Editor
    {
        protected int localIdentfierInFile;
        protected AFixedTransform aFixedTransform;
        protected Transform transform;
        
        private SerializedProperty ser_showableChildren;
        
        protected virtual void OnEnable()
        {
            aFixedTransform = ((AFixedTransform) target);
            localIdentfierInFile = EditorGUILayoutUtilities.GetLocalIdentfierInFile(aFixedTransform);
            transform = aFixedTransform.transform;
            ser_showableChildren = serializedObject.FindProperty("showableChildren");
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
            
            if (aFixedTransform.EditorRepaint)
            {
                aFixedTransform.EditorRepaint = false;
                int childCount = transform.childCount;
                if (aFixedTransform.showableChildren.Length != childCount)
                {
                    aFixedTransform.showableChildren = new AFixedTransform.ShowableTransform[childCount];
                }

                for (int i = 0; i < childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    aFixedTransform.showableChildren[i] = new AFixedTransform.ShowableTransform(child);
                }
            }
            
            EditorGUILayout.PropertyField(ser_showableChildren, true);

            GUI.enabled = guiEnabled;

            serializedObject.ApplyModifiedProperties();
        }
    }
}