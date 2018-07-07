# Unity-FixedTransform
-------------------------------------------------------

# Purpose: 
Keep the local position of target transform to Vector3.zero.
Keep the local euler angles of target transform to Vector3.zero.
Keep the local scale of target transform to Vector3.one.
Children are moved of the same amount that their parent has moved.
It presents two version: 
a) it runs in Update regardless anything;
b) it runs only when Setup is requested;
  
# Usage: 
1) Hierarchy foldering, usually during editor only (or at least is suggested this kind of usage).

# How it works:
1) Assign this* component a target GameObject.
2) Assign this* component to each target's interested child.

* *= any fixed transform component.