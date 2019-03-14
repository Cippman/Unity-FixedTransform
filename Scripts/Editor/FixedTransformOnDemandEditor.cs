/*
 *  Author: Alessandro Salani (Cippman)
 */

using CippSharp;
using UnityEditor;
using UnityEngine;

namespace CippSharpEditor
{
    [CustomEditor(typeof(FixedTransformOnDemand))]
    public class FixedTransformOnDemandEditor : AFixedTransformEditor
    {
        protected const string commandsHeader = "Commands:";
        protected const string setupButtonName = "Setup";
        
        public override void OnInspectorGUI()
        {
            DrawAFixedTransformData();
            DrawFixedTransformOnDemandInspector();
            DrawAFixedTransformInspector();
        }

        protected void DrawFixedTransformOnDemandInspector()
        {
            EditorGUILayoutUtils.DrawHeader(commandsHeader);
            
            if (fixedTransform is FixedTransformOnDemand)
            {
                EditorGUILayoutUtils.DrawMiniButton(setupButtonName, SetupCallback);
            }
            
            GUILayout.Space(5);
        }

        private void SetupCallback()
        {
            ((FixedTransformOnDemand)fixedTransform).Setup();
        }
    }
}