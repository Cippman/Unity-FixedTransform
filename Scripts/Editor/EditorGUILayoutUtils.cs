/*
 *  Author: Alessandro Salani (Cippman)
 */
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Reflection;

namespace CippSharpEditor
{
    public static class EditorGUILayoutUtils
    {
        /// <summary>
        /// Call this only in custom editor enable! It retrieves the m_LocalIdentfierInFile of a Object.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetLocalIdentfierInFile(Object target)
        {
            PropertyInfo inspectorModeInfo = typeof(UnityEditor.SerializedObject).GetProperty ("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
         
            UnityEditor.SerializedObject serializedObject = new UnityEditor.SerializedObject (target); 
            
            inspectorModeInfo.SetValue (serializedObject, UnityEditor.InspectorMode.Debug, null);

            UnityEditor.SerializedProperty localIdProp = serializedObject.FindProperty("m_LocalIdentfierInFile");  
           
            return localIdProp.intValue;
        }
        
        /// <summary>
        /// It help to draw easily infos of a class in custom editors.
        /// </summary>
        /// <param name="serializedObject"></param>
        /// <param name="localIdentfierInFile"></param>
        public static void DrawObjectData(SerializedObject serializedObject, int localIdentfierInFile = 0)
        {
            EditorGUILayout.BeginVertical();
            var guiStatus = GUI.enabled;
            GUI.enabled = false;
            
            Object targetObject = serializedObject.targetObject;
            int instanceID = targetObject.GetInstanceID();
            EditorGUILayout.IntField("Instance ID", instanceID);                //Returns only identifiers of assets, not scene objects.
            int identfier = (localIdentfierInFile != 0) ? localIdentfierInFile : Unsupported.GetLocalIdentifierInFile(instanceID);
            EditorGUILayout.IntField("Local Identfier in File", identfier);
            
            SerializedProperty m_Script = serializedObject.FindProperty("m_Script");
            EditorGUILayout.PropertyField(m_Script);
            EditorGUILayout.ObjectField("Self", targetObject, typeof(Object), true);
            
            GUI.enabled = guiStatus;
            EditorGUILayout.EndVertical();
        }
        
        /// <summary>
        /// Draws an header.
        /// </summary>
        /// <param name="content"></param>
        public static void DrawHeader(string content)
        {
            GUILayout.Space(3);
            EditorGUILayout.LabelField(content, EditorStyles.boldLabel);
            GUILayout.Space(2);
        }
        
        /// <summary>
        /// Draws a mini button
        /// </summary>
        /// <param name="content"></param>
        /// <param name="action"></param>
        public static void DrawMiniButton(string content, UnityAction action)
        {
            if (GUILayout.Button(content, EditorStyles.miniButton))
            {
                if (action != null)
                {
                    action();
                }
            }
        }
    }
}
