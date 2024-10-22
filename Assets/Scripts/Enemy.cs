using UnityEngine;

[RequireComponent(typeof(WalkAnimationHandler), (typeof(Walker)))]
[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private WalkAnimationHandler _walkAnimationHandler;
    [SerializeField] private Walker _walker;
    [SerializeField] private Patrol _patrol;

    private void OnValidate()
    {
        WalkAnimationHandler walkAnimationHandler = GetComponent<WalkAnimationHandler>();
        Walker walker = GetComponent<Walker>();  
        Patrol patrol = GetComponent<Patrol>();
        
        if (_walkAnimationHandler != null || _walkAnimationHandler != walkAnimationHandler)
            _walkAnimationHandler = walkAnimationHandler;

        if (_walker != null || _walker != walker)
            _walker = walker;

        if (_patrol != null || _patrol != patrol)
            _patrol = patrol;
    }

    private void FixedUpdate()
    {
        _walker.Walk(_patrol.Direction);
        _walkAnimationHandler.Walk(_patrol.Direction);
    }
}
