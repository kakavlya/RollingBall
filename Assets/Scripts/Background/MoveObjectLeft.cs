using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectLeft : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _leftWaypointX = -8f;
    [SerializeField] private float _rightWaypointX = 8f;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + _moveSpeed * Time.deltaTime,
            transform.position.y);

        if (transform.position.x < _leftWaypointX)
            transform.position = new Vector2(_rightWaypointX, transform.position.y);
    }
}
