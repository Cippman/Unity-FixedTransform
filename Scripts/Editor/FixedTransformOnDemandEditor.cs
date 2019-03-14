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
        protected const string ensure2DButtonName = "Ensure 2D";

        protected const string mainCameraTag = "MainCamera";
        
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
            
            if (fixedTransform is FixedTransformOnDemand)
            {
                EditorGUILayoutUtils.DrawMiniButton(ensure2DButtonName, ZerifyLocalPositionZeta);
            }

        }

        private void SetupCallback()
        {
            ((FixedTransformOnDemand)fixedTransform).Setup();
        }
        
        private void ZerifyLocalPositionZeta()
        {
            Transform[] children = transform.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < children.Length; i++)
            {
                Transform child = children[i];
                if (child.gameObject.tag == mainCameraTag)
                {
                    continue;
                }

                if (child.localPosition.z == 0)
                {
                    continue;
                }

                Vector3 localPosition = child.localPosition;
#if NET_4_6
                Debug.Log(FixedTransformOnDemand.LogName+ $"Found {child.gameObject.name} with not correct local position zeta: {localPosition.z.ToString("F4")}.", child);
#else
                Debug.Log(FixedTransformOnDemand.LogName+string.Format("Found {0} with not correct local position zeta: {1}.", child.name, localPosition.z.ToString("F4")), child);
#endif
                localPosition.z = 0;
                child.localPosition = localPosition;
                EditorUtility.SetDirty(child);
            }
        }
    }
}
