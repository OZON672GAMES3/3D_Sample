using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;
    
    private CharacterController _characterController;
    private float _directionHorizontal;
    private float _directionVertical;
    private Vector3 _movement;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _directionVertical = Input.GetAxis(Vertical);
        _directionHorizontal = Input.GetAxis(Horizontal);

        _movement = transform.forward * _directionVertical + transform.right * _directionHorizontal;

        _characterController.Move(_movement * (_speed * Time.fixedDeltaTime));
    }
}