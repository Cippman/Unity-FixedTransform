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
        protected const string infosHeader = "Infos:";
        
        protected int localIdentfierInFile;
        protected AFixedTransform fixedTransform;
        protected Transform transform;
        
        private SerializedProperty ser_showableChildren;
        
        protected void OnEnable()
        {
            fixedTransform = ((AFixedTransform) target);
            localIdentfierInFile = EditorGUILayoutUtils.GetLocalIdentfierInFile(fixedTransform);
            transform = fixedTransform.transform;
            #if NET_4_6
            ser_showableChildren = serializedObject.FindProperty(nameof(AFixedTransform.children));
            #else 
            ser_showableChildren = serializedObject.FindProperty("children");
            #endif
        }

        public override void OnInspectorGUI()
        {
            DrawAFixedTransformData();
            DrawAFixedTransformInspector();
        }

        protected void DrawAFixedTransformData()
        {
            EditorGUILayoutUtils.DrawObjectData(serializedObject, localIdentfierInFile);
        }

        protected void DrawAFixedTransformInspector()
        {
            serializedObject.Update();
            
            EditorGUILayoutUtils.DrawHeader(infosHeader);
            bool guiStatus = GUI.enabled;
            GUI.enabled = false;
            
            if (fixedTransform.EditorRepaint)
            {
                fixedTransform.EditorRepaint = false;
                
                int childCount = transform.childCount;
                if (fixedTransform.children.Length != childCount)
                {
                    fixedTransform.children = new AFixedTransform.ShowableTransform[childCount];
                }

                for (int i = 0; i < childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    fixedTransform.children[i] = new AFixedTransform.ShowableTransform(child);
                }
            }
            
            EditorGUILayout.PropertyField(ser_showableChildren, true);
            GUI.enabled = guiStatus;
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}