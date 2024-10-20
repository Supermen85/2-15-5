using UnityEngine;

[RequireComponent(typeof(WalkAnimationHandler))]
[RequireComponent(typeof(Walker))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _waypoint1;
    [SerializeField] private Transform _waypoint2;
    [SerializeField] private float _minDistance = 0.3f;

    private WalkAnimationHandler _walkAnimationHandler;
    private Walker _walker;
    private Transform _currentWaypoint;

    private float _direction;

    private void Awake()
    {
        _walkAnimationHandler = GetComponent<WalkAnimationHandler>();
        _walker = GetComponent<Walker>();  
    }

    private void Start()
    {
        _currentWaypoint = _waypoint1;
        _direction = _currentWaypoint.transform.position.x - transform.position.x;
    }

    private void FixedUpdate()
    {
        _walker.Walk(_direction);
        _walkAnimationHandler.Walk(_direction);
    }

    private void Update()
    {
        if (IsCloseEnough())
            ChangeDirection();
    }

    private bool IsCloseEnough()
    {
        float distance = _currentWaypoint.transform.position.x - transform.position.x;
        
        if (distance < 0)
            distance *= -1;

        return (distance < _minDistance);
    }

    private void ChangeDirection()
    {
        _currentWaypoint = (_currentWaypoint == _waypoint1) ? _waypoint2 : _waypoint1;
        _direction = _currentWaypoint.transform.position.x - transform.position.x;
    }
}
