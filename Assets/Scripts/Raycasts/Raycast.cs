using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _rayStartPoint;
    [SerializeField] private Text _text;

    private Ray _ray;
    private Ray _ray2;
    private Vector3 _mousePosition;
    private RaycastHit _raycastHit;

    private void Update()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        _mousePosition = Input.mousePosition;

        _ray2 = new Ray(_rayStartPoint.position, new Vector3(_mousePosition.x, _mousePosition.y, 4));
        
        Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.blue);
        Debug.DrawRay(_ray2.origin, _ray2.direction * _rayDistance, Color.red);

        if (Physics.Raycast(_ray, out _raycastHit))
            if (_raycastHit.transform.TryGetComponent(out RayCube rayCube))
            {
                _text.text = Convert.ToString(_raycastHit.distance);
                rayCube.ChangeColor();
            }

        if (Physics.Raycast(_ray2, out _raycastHit))
            if (_raycastHit.transform.TryGetComponent(out RayCube rayCube))
                rayCube.ChangeColor();
    }
}