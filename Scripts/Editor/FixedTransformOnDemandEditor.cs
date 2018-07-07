
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
            if (target is FixedTransformOnDemand)
            {
                if (GUILayout.Button("Setup", EditorStyles.miniButton))
                {
                    ((FixedTransformOnDemand)target).Setup(true);
                }
                
                GUILayout.Space(5);
            }
            
            base.OnInspectorGUI();           
        }
    }
}