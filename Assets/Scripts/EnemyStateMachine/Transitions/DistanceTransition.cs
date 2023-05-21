using System;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange = 5f;
    [SerializeField] private bool _isTransitionOnDistanceLess;
    
    private void Update()
    {
        if(Target == null)
            return;
        
        if (_isTransitionOnDistanceLess
            ? Vector2.Distance(transform.position, Target.transform.position) < _transitionRange 
            : Vector2.Distance(transform.position, Target.transform.position) > _transitionRange)
        {
            _needTransit = true;
        }
    }
}
