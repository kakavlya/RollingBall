using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnPositionRange))]
public class CoinsGenerator : GameObjectsGenerator
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    private SpawnPositionRange _range;

    private float _elapsedTime = 0;
    private void Awake()
    {
        Initialize(_template);
        _range = GetComponent<SpawnPositionRange>();
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
        int numbersInLine = Random.Range(_range.MinItemsInLine, _range.MaxItemsInLine);
        float spawnPositionY = Random.Range(_range.MinSpawnYPos, _range.MaxSpawnYPos);
        float currentXPosition = transform.position.x;

        for (int i = 0; i < numbersInLine; i++)
        {
            if (TryGetObject(out GameObject spawnedObject))
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

        DisableObjectAbroadTheScreen();
    }
}
