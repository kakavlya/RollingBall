using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnYPos;
    [SerializeField] private float _minSpawnYPos;
    [SerializeField] private int _minItemsInLine;
    [SerializeField] private int _maxItemsInLine;

    private Range _yPosRange;
    private Range _coinsRange;
    private float _elapsedTime = 0;
    private GameObjectsPool _objectPools;

    private void Awake()
    {
        _objectPools = new GameObjectsPool();
        _objectPools.Initialize(_template, _capacity, _container);
        _yPosRange = new Range(_minSpawnYPos, _maxSpawnYPos);
        _coinsRange = new Range(_minItemsInLine, _maxItemsInLine);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            GenerateCoinsLine();
            _elapsedTime = 0;
        }
    }

    private void GenerateCoinsLine()
    {
        int numbersInLine = (int)_coinsRange.GetRandInRange();
        float spawnPositionY = _yPosRange.GetRandInRange();
        float currentXPosition = transform.position.x;

        for (int i = 0; i < numbersInLine; i++)
        {
            if (_objectPools.TryGetObject(out GameObject spawnedObject))
            {
                SpawnObject(spawnedObject, currentXPosition, spawnPositionY);
                currentXPosition += 0.9f;
            }
        }
    }

    private void SpawnObject(GameObject spawnedObject, float currentXPosition, float spawnPositionY)
    {
        Vector3 spawnPosition = new Vector3(currentXPosition, spawnPositionY, transform.position.z);
        spawnedObject.SetActive(true);
        spawnedObject.transform.position = spawnPosition;

        _objectPools.DisableObjectAbroadTheScreen();
    }

    public void ResetPool()
    {
        _objectPools.ResetPool();
    }
}
