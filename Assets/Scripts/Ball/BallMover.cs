using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundCheckParams))]
public class BallMover: MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Vector2 _startPosition;
    private GroundCheckParams _groundCheckParams;

    private bool _isGrounded;
    private Rigidbody2D _body;
    private float _movement;
    private const string Jump = "Jump"; 

    public void ResetPosition()
    {
        
        _body.position = _startPosition;
        _body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX;
    }

    private void Start()
    {
        _groundCheckParams = GetComponent<GroundCheckParams>();
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(_movingSpeed, _body.velocity.y);
    }


    private void Update()
    {
        CheckIfGrounded();
        if (Input.GetButtonDown(Jump) && _isGrounded)
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
    }

    private void CheckIfGrounded()
    {
        var groundedPosition = _groundCheckParams.GroundCheck.position;
        var groundCheckRadius = _groundCheckParams.GroundCheckRadius;
        var groundLayer = _groundCheckParams.GroundLayer;
        _isGrounded = Physics2D.OverlapCircle(groundedPosition, groundCheckRadius, groundLayer);
    }
}
