using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] private float _minSpawnPosition;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private GameObjectsPool _objectPools;
    private float _elapsedTime = 0;

    private void Awake()
    {
        _objectPools = new GameObjectsPool();
        _objectPools.Initialize(_template, _capacity, _container);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if(_objectPools.TryGetObject(out GameObject spawnedObject))
            {
                _elapsedTime = 0;
                SpawnObject(spawnedObject);
            }
        }
    }

    private void SpawnObject(GameObject spawnedObject)
    {
        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        spawnedObject.SetActive(true);
        spawnedObject.transform.position = spawnPosition;

        _objectPools.DisableObjectAbroadTheScreen();
    }

    public void ResetPool()
    {
        _objectPools.ResetPool();
    }
}
