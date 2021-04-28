using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : GameObjectsGenerator
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] private float _minSpawnPosition;

    private float _elapsedTime = 0;

    private void Awake()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject spawnedObject))
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

        DisableObjectAbroadTheScreen();
    }
}
