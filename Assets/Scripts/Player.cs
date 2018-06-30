using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Inspector fields.
    [SerializeField] private float _speed = 250.0f;

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

        // Velocity.
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        // Animation.
        _animator.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
}
