using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private Coin _coin;
    private Transform _currentSpawnPoint;

    private void Start()
    {
        _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        _coin = Instantiate(_coinPrefab, _currentSpawnPoint.position, Quaternion.identity);
        _coin.Collected += ChangePosition;

        _coin.transform.position = _currentSpawnPoint.position;
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