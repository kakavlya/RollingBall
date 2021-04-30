using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectsMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _leftWaypointXposition;
    [SerializeField] private float _rightWaypointXposition;

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.x < _leftWaypointXposition)
            transform.position = new Vector2(_rightWaypointXposition, transform.position.y);
    }
}
