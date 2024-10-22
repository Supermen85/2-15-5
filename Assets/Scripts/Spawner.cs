using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private Coin _coin;
    private Transform _currentSpawnPoint;

    private void Awake()
    {
        _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        _coin = Instantiate(_coinPrefab, _currentSpawnPoint.position, Quaternion.identity);

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
        Transform previousSpawnpoint = _currentSpawnPoint;

        do
        {
            _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        }
        while (previousSpawnpoint == _currentSpawnPoint);

        _coin.transform.position = _currentSpawnPoint.position;
    }
}