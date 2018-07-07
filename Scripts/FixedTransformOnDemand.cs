﻿/*
 *  Author: Alessandro Salani (Cippman)
 */
using UnityEngine;

namespace CippSharp
{
	[ExecuteInEditMode]
	public class FixedTransformOnDemand : AFixedTransform
	{
		/// <summary>
		/// Target, this transform.
		/// </summary>
		private Transform target;

		//Runtime:
		/// <summary>
		/// Keep track of the current local position of the target
		/// </summary>
		private Vector3 currentLocalPosition;
		/// <summary>
		/// Keep track of the current local euler angles of the target
		/// </summary>
		private Vector3 currentLocalEulerAngles;
		/// <summary>
		/// Keep track of the current local scale of the target
		/// </summary>
		private Vector3 currentLocalScale;

		private void OnEnable()
		{
			target = transform;
		}

		/// <summary>
		/// Call this after editing target's localPosition, and all children directly under target (as parent)
		/// will be repositioned by keeping target's localPosition to Vector3.zero and by moving children by offset.
		/// </summary>
		/// <param name="affectNestedFixedTransformOnDemandComponents">Tells to affect children component of FixedTransformOnDemand</param>
		public void Setup(bool affectNestedFixedTransformOnDemandComponents = true)
		{
			currentLocalPosition = target.localPosition;
			bool positionIsDirty = currentLocalPosition != Vector3.zero;
			currentLocalEulerAngles = target.localEulerAngles;
			bool rotationIsDirty = currentLocalEulerAngles != Vector3.zero;
			currentLocalScale = target.localScale;
			bool scaleIsDirty = currentLocalScale != Vector3.one;

			if (positionIsDirty || rotationIsDirty || scaleIsDirty)
			{
				Vector3 deltaLocalPosition = currentLocalPosition - Vector3.zero;
				Vector3 deltaLocalEulerAngles = currentLocalEulerAngles - Vector3.zero;
				Vector3 deltaLocalScale = currentLocalScale - Vector3.one;
				target.localPosition = Vector3.zero;
				target.localEulerAngles = Vector3.zero;
				target.localScale = Vector3.one;
				
				for (int i = 0; i < target.childCount; i++)
				{
					Transform child = target.GetChild(i);
					if (positionIsDirty)
					{
						child.localPosition = deltaLocalPosition;
					}

					if (rotationIsDirty)
					{
						child.localEulerAngles = deltaLocalEulerAngles;
					}

					if (scaleIsDirty)
					{
						child.localScale = deltaLocalScale;
					}

					if (affectNestedFixedTransformOnDemandComponents)
					{
						FixedTransformOnDemand fixedTransformOnDemand = child.GetComponent<FixedTransformOnDemand>();
						if (fixedTransformOnDemand != null)
						{
							fixedTransformOnDemand.Setup(affectNestedFixedTransformOnDemandComponents);
						}
					}
				}
#if UNITY_EDITOR
				EditorRepaint = true;
#endif
			}
		}
	}
}