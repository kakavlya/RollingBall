using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectsPool))]
public abstract class ObjectsGenerator : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenSpawn;

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

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            Generate();
            _elapsedTime = 0;
        }
    }

    protected abstract void Generate();

    protected void SpawnObject(GameObject spawnedObject, Vector3 spawnPosition)
    {
        spawnedObject.SetActive(true);
        spawnedObject.transform.position = spawnPosition;

        _objectPools.DisableObjectAbroadTheScreen();
    }    

    protected bool IsObjectAvailable(out GameObject spawnedObject)
    {
        return _objectPools.TryGetObject(out spawnedObject);
    }

    public void Reset()
    {
        _objectPools.ResetPool();
    }
}
