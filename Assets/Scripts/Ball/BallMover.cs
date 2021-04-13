using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover: MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 2f;
    [SerializeField]
    private float _movingSpeed = 2f;
    [SerializeField]
    private float _groundCheckRadius = 2f;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private Vector2 _startPosition;

    private bool _isGrounded;
    private Rigidbody2D _body;

    internal void ResetPosition()
    {
        _body.position = _startPosition;
        _body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX;
    }

    private float _movement;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(_movingSpeed, _body.velocity.y);
    }


    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        //_movement = Input.GetAxis("Horizontal");

        //if (_movement != 0f)
        //{
        //    _body.velocity = new Vector2(_movement * _movingSpeed, _body.velocity.y);
        //} else
        //{
        //    _body.velocity = new Vector2(0, _body.velocity.y);
        //}
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
        }
    }
}
