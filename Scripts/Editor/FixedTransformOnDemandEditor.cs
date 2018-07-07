/*
 *  Author: Alessandro Salani (Cippman)
 */
using CippSharp;
using UnityEditor;
using UnityEngine;

namespace CippSharpEditor
{
    [CustomEditor(typeof(FixedTransformOnDemand))]
    public class FixedTransformOnDemandEditor : FixedTransformEditor
    {
        public override void OnInspectorGUI()
        {
            DrawAFixedTransformData();
            DrawFixedTransformOnDemandInspector();
            DrawAFixedTransformInspector();
        }

        protected void DrawFixedTransformOnDemandInspector()
        {
            EditorGUILayoutUtilities.DrawHeader("Commands:");
            
            if (aFixedTransform is FixedTransformOnDemand)
            {
                EditorGUILayoutUtilities.DrawMiniButton("Setup", SetupCallback);
            }
            
            GUILayout.Space(5);
        }

        private void SetupCallback()
        {
            ((FixedTransformOnDemand)aFixedTransform).Setup(true);
        }
    }
}