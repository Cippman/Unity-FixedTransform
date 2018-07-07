/*
 *  Author: Alessandro Salani (Cippman)
 */
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
        /// <summary>
        /// Fold in inspector showed children.
        /// </summary>
        public bool showChildrenLocalPositionInfo;
        #endif
    }
}