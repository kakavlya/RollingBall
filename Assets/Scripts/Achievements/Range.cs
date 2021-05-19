using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range 
{
    private float _minNum;
    private float _maxNum;

    public Range(float minNum, float maxNum)
    {
        _minNum = minNum;
        _maxNum = maxNum;
    }

    public float GetRandInRange()
    {
        return Random.Range(_minNum, _maxNum);
    }
}
