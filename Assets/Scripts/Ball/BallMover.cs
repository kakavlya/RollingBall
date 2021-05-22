using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundedCheck))]
public class BallMover: MonoBehaviour
{
    private const string Jump = "Jump";

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Vector2 _startPosition;

    private GroundedCheck _groundedCheck;
    private Rigidbody2D _body;
    private float _movement;

    private void Start()
    {
        _groundedCheck = GetComponent<GroundedCheck>();
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(_movingSpeed, _body.velocity.y);
    }


    private void Update()
    {
        if (Input.GetButtonDown(Jump) && _groundedCheck.IsGrounded())
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
    }

    public void ResetPosition()
    {
        _body.position = _startPosition;
        _body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX;
    } 
}
