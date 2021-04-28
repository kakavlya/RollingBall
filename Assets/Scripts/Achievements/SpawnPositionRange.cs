using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class SpawnPositionRange: MonoBehaviour
{
        [SerializeField] private float _maxSpawnYPos;
        [SerializeField] private float _minSpawnYPos;
        [SerializeField] private int _minItemsInLine;
        [SerializeField] private int _maxItemsInLine;

        public float MaxSpawnYPos { get => _maxSpawnYPos; }
        public float MinSpawnYPos { get => _minSpawnYPos; }
        public int MinItemsInLine { get => _minItemsInLine; }
        public int MaxItemsInLine { get => _maxItemsInLine; }
}

