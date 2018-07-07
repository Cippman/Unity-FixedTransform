/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;

namespace CippSharp
{
    /// <summary>
    /// Abstract class for FixedtTransform. It allow a easier custom editor management.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class AFixedTransform : MonoBehaviour
    {
#if UNITY_EDITOR
        [Serializable]
        public struct ShowableTransform
        {
            [HideInInspector] public string name;
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;

            public ShowableTransform(Transform target)
            {
                name = target.name;
                position = target.localPosition;
                rotation = target.localEulerAngles;
                scale = target.localScale;
            }
        }
        
        /// <summary>
        /// Fold in inspector showed children.
        /// </summary>
        public bool showChildren;

        /// <summary>
        /// Holds children transform most common data
        /// </summary>
        [SerializeField] public ShowableTransform[] showableChildren = new ShowableTransform[0];

        /// <summary>
        /// Tells to editor class if need a refresh.
        /// Optimization purpose only.
        /// </summary>
        public virtual bool EditorRepaint { get; set; }
#endif
    }
}