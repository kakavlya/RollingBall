using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectsPool))]
public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Range _yPosRange;
    [SerializeField] private Range _coinsRange;
    private float _elapsedTime = 0;
    private GameObjectsPool _objectPools;

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
            GenerateCoinsLine();
            _elapsedTime = 0;
        }
    }

    private void GenerateCoinsLine()
    {
        int numbersInLine = (int)_coinsRange.Next();
        float spawnPositionY = _yPosRange.Next();
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

    public void Reset()
    {
        _objectPools.ResetPool();
    }
}
