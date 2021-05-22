using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectsPool))]
public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] private float _minSpawnPosition;

    private GameObjectsPool _objectPools;
    private float _elapsedTime = 0;

    private void Awake()
    {
        _objectPools = GetComponent<GameObjectsPool>();
        _objectPools.Initialize();
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

    public void Reset()
    {
        _objectPools.ResetPool();
    }
}
