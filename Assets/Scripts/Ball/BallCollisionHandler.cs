﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallCollisionHandler : MonoBehaviour
{
    private Ball _ball;

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ScoreCollider scoreCollider))
        {
            _ball.IncreaseScore();
        }
        else
        {
            _ball.Die();
        }
    }
}
