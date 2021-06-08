using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = -5f;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    private void Update()
    {
        transform.position = new Vector2(
            transform.position.x + _moveSpeed * Time.deltaTime, transform.position.y);
    }
}
