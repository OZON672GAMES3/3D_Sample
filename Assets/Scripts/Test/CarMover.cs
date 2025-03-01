using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class CarMover : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    
    private float _maxSpeed = 20f;
    private float _deceleration = 5f;
    private float _input;
    private float _currentSpeed;

    private void Update()
    {
        _input = Input.GetAxis("Vertical");
        
        if (_input != 0)
            _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed * _input, _acceleration * Time.deltaTime);
        else
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0, _deceleration * Time.deltaTime);
        
        transform.Translate(Vector3.forward * (_currentSpeed * Time.deltaTime));
    }
}
