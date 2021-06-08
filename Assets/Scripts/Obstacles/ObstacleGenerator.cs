using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectsPool))]
public class ObstacleGenerator : ObjectsGenerator
{
    [SerializeField] private float _maxSpawnPosition;
    [SerializeField] private float _minSpawnPosition;

    protected override void Generate()
    {
        float spawnPositionY = Random.Range(_minSpawnPosition, _maxSpawnPosition);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        if (IsObjectAvailable(out GameObject spawnedObject))
        {
            SpawnObject(spawnedObject, spawnPosition);
        }
    }
}
