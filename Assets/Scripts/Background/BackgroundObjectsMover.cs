using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectsMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rightWaypointXPos;
    [SerializeField] private float _leftWaypointXPos;

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.x < _rightWaypointXPos)
            transform.position = new Vector2(_leftWaypointXPos, transform.position.y);
    }
}
