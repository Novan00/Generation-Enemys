
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _spawnDelay = 2f;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            yield return delay; 

            var spawnPoint = Random.Range(0, _spawnPoints.Count);

            Enemy enemy = Instantiate(_enemy, _spawnPoints[spawnPoint].transform.position, Quaternion.identity);

            enemy.SetRandomDirection();
        }
    }
}
