using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraban : MonoBehaviour
{
    private float _currentSpeed;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _currentSpeed = Random.Range(300f, 600f);

        if (_currentSpeed > 0)
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * (_currentSpeed * Time.deltaTime));
        _currentSpeed -= Time.deltaTime * 50f;
    }
}