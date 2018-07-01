﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Inspector fields.
    [SerializeField] private float _speed = 250.0f;
    [SerializeField] private float _jumpForce = 12.0f;

    // Components.
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private BoxCollider2D _boxCollider;

    void Start()
    {
        // Components.
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Input.
        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        // Horizontal movement.
        Vector2 movement = new Vector2(deltaX, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;

        // Jump movement.
        bool isGrounded = IsGrounded();
        _rigidbody.gravityScale = isGrounded && deltaX == 0 ? 0 : 1;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        // Animations.
        _animator.SetFloat("velocityY", _rigidbody.velocity.y);
        _animator.SetBool("isGrounded", isGrounded);
        _animator.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }

    private bool IsGrounded()
    {
        Vector3 max = _boxCollider.bounds.max;
        Vector3 min = _boxCollider.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        return hit != null;
    }
}
