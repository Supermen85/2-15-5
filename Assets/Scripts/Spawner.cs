using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint1;
    [SerializeField] private Transform _spawnPoint2;
    [SerializeField] private Coin _coin;

    private Transform _currentSpawnPoint;

    private void Start()
    {
        _currentSpawnPoint = _spawnPoint1;
        _coin.transform.position = _currentSpawnPoint.position;
    }

    private void OnEnable()
    {
        _coin.Collected += ChangePosition;
    }

    private void OnDisable()
    {
        _coin.Collected -= ChangePosition;
    }

    private void ChangePosition()
    {
        _currentSpawnPoint = (_currentSpawnPoint == _spawnPoint1 ? _spawnPoint2 : _spawnPoint1);
        _coin.transform.position = _currentSpawnPoint.position;
    }
}
