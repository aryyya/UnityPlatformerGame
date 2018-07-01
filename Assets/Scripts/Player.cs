using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Inspector fields.
    [SerializeField] private float _speed = 250.0f;
    [SerializeField] private float _jumpForce = 12.0f;

    // Components.
    private Rigidbody2D _body;
    private Animator _animator;

    void Start()
    {
        // Components.
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input.
        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        // Horizontal movement.
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        // Jump movement.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        // Animation.
        _animator.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}
