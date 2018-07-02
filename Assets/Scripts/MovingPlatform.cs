using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Inspector fields.
    [SerializeField] private Vector3 _finishPosition = Vector3.zero;
    [SerializeField] private float _speed = 0.5f;

    private Vector3 _startPosition;
    private float _trackPercentage = 0.0f;
    private int _direction = +1;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        // Determine new X and Y coordinates.
        _trackPercentage += _direction * _speed * Time.deltaTime;
        float x = (_finishPosition.x - _startPosition.x) * _trackPercentage + _startPosition.x;
        float y = (_finishPosition.y - _startPosition.y) * _trackPercentage + _startPosition.y;
        transform.position = new Vector3(x, y, _startPosition.z);

        // Switch direction if at end of track.
        if ((_direction == +1 && _trackPercentage > 0.9f) || (_direction == -1 && _trackPercentage < 0.1f))
        {
            _direction *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _finishPosition);
    }
}
