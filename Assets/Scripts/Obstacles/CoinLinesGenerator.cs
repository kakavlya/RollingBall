using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLinesGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnYPos;
    [SerializeField] private float _minSpawnYPos;
    [SerializeField] private int _minItemsInLine;
    [SerializeField] private int _maxItemsInLine;

    private float _elapsedTime = 0;

    private void Awake()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            int numbersInLine = Random.Range(_minItemsInLine, _maxItemsInLine);
            float spawnPositionY = Random.Range(_minSpawnYPos, _maxSpawnYPos);
            float currentXPosition = transform.position.x;

            for (int i = 0; i < numbersInLine; i++)
            {    
                if (TryGetObject(out GameObject spawnedObject))
                {
                    
                    // temp code
                    //Vector3 spawnPosition = new Vector3(currentXPosition, spawnPositionY, transform.position.z);
                    //GameObject spawned = Instantiate(_template);
                    //spawned.transform.position = spawnPosition;
                    // end of temp code
                    SpawnObject(spawnedObject, currentXPosition, spawnPositionY);
                    currentXPosition += 0.9f;
                }
            }
            _elapsedTime = 0;
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
