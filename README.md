# Unity-FixedTransform
-------------------------------------------------------

# Purpose: 
Keep the local position of target transform to Vector3.zero.
Keep the local euler angles of target transform to Vector3.zero.
Keep the local scale of target transform to Vector3.one.
Children are moved of the same amount that their parent has moved.

 #Contents:
1) a script that runs in Update regardless anything;
2) a script that works only when Setup is called;
  
# Usage: 
1) Hierarchy foldering, usually during editor only (or at least is suggested this kind of usage).

# How it works:
1) Assign this* component a target GameObject.
2) Assign this* component to each target's interested child.

*= any fixed transform component.