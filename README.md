# Unity-FixedTransform
-------------------------------------------------------

# Purpose: 
Keep the local position of target transform to Vector3.zero.
Children are moved of the same amount that their parent should move.
It presents two version: a) it runs in Update regardless anything; b) it runs only when Setup is requested;
  
# Usage: 
Hierarchy foldering, during editor only (or at least is suggested this kind of usage).

# How it works:
1) Assign this* component a target GameObject.
2) Assign this* component to each target's interested child.

* *= any fixed transform component.
