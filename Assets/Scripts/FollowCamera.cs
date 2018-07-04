using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Inspector fields.
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;

    void LateUpdate()
    {
        // Change to target position with a smooth delay.
        Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
