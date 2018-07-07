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
            if (aFixedTransform is FixedTransformOnDemand)
            {
                if (GUILayout.Button("Setup", EditorStyles.miniButton))
                {
                    ((FixedTransformOnDemand)aFixedTransform).Setup(true);
                }
                
                GUILayout.Space(5);
            }
            
            base.OnInspectorGUI();           
        }
    }
}