using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _enemyProjectilePrefab;
    [SerializeField] Transform _spawnPoint;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _timeBetweenSpawns;
    [Range(0, 100)]
    [SerializeField] float _timeToSpawn;
    [Range(0, 100)]
    [SerializeField] float _spawnSpeed;


    private void Start()
    {
        _timeToSpawn = _timeBetweenSpawns;
    }
    public void SpawningTimer()
    {
        _timeToSpawn -= 50 * Time.deltaTime;
        _timeToSpawn = Mathf.Clamp(_timeToSpawn, 0, _timeBetweenSpawns);

        if(_timeToSpawn == 0)
        {
            Spawn();
            _timeToSpawn = _timeBetweenSpawns;
        }
    }
    private void Spawn()
    {
        Instantiate(_enemyProjectilePrefab, _spawnPoint.position, Quaternion.identity);
    }
}
