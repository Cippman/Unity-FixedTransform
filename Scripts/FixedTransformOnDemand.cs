/*
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
		/// Keep track of the delta local position (movement amount) of the target.
		/// This is calculated before assigning it to children.
		/// </summary>
		private Vector3 deltaLocalPosition = Vector3.zero;

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

			if (currentLocalPosition != Vector3.zero)
			{
				deltaLocalPosition = currentLocalPosition - Vector3.zero;
				target.localPosition = Vector3.zero;
				for (int i = 0; i < target.childCount; i++)
				{
					Transform child = target.GetChild(i);
					child.localPosition += deltaLocalPosition;
					if (affectNestedFixedTransformOnDemandComponents)
					{
						FixedTransformOnDemand fixedTransformOnDemand = child.GetComponent<FixedTransformOnDemand>();
						if (fixedTransformOnDemand != null)
						{
							fixedTransformOnDemand.Setup(affectNestedFixedTransformOnDemandComponents);
						}
					}
				}
			}
		}
	}
}