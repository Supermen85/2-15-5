using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 0.3f;

    private Transform _currentWaypoint;
    
    public float Direction { get; private set; }

    private void Start()
    {
        _currentWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
        Direction = _currentWaypoint.position.x - transform.position.x;
    }

    private void FixedUpdate()
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
        Transform previousWaypoint = _currentWaypoint;

        do
        {
            _currentWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
        }
        while (_currentWaypoint == previousWaypoint);

        Direction = _currentWaypoint.transform.position.x - transform.position.x;
    }
}
