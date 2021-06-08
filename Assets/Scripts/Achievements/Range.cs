using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float Next()
    {
        return Random.Range(_min, _max);
    }
}
