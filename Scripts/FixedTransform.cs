/*
 *  Author: Alessandro Salani (Cippman)
 */
using UnityEngine;

namespace CippSharp
{
	[ExecuteInEditMode]
	public class FixedTransform : AFixedTransform
	{
		//At Begin:
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
		/// Every frame checks and move children if target's position was changed.
		/// </summary>
		private void Update()
		{
			currentLocalPosition = target.localPosition;
			
			if (currentLocalPosition != Vector3.zero)
			{
				deltaLocalPosition = currentLocalPosition - Vector3.zero;
				target.localPosition = Vector3.zero;
				for (int i = 0; i < target.childCount; i++)
				{
					target.GetChild(i).localPosition += deltaLocalPosition;
				}
			}
		}
	}
}