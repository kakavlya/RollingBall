using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectsPool))]
public class CoinsGenerator : ObjectsGenerator
{
    [SerializeField] private Range _yPosRange;
    [SerializeField] private Range _coinsRange;

    protected override void Generate()
    {
        int numbersInLine = (int)_coinsRange.Next();
        float spawnPositionY = _yPosRange.Next();
        float currentXPosition = transform.position.x;
  
        for (int i = 0; i < numbersInLine; i++)
        {
            Vector3 spawnPosition = new Vector3(currentXPosition, spawnPositionY, transform.position.z);
            if (IsObjectAvailable(out GameObject spawnedObject))
            {
                SpawnObject(spawnedObject, spawnPosition);
                currentXPosition += 0.9f;
            }
        }
    }
}
