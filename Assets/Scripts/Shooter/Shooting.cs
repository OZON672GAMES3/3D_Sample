using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private PointImpact _prefab;
    [SerializeField] private Transform _startPointRay;
    [SerializeField] private float _fireRate;

    private RaycastHit _raycastHit;
    private Ray _ray;
    private Camera _camera;
    private PointImpact _tempPointImpact;
    private float _nextFireTime = 0f;

    private void Start()
    {
        _camera = GetComponentInParent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            ShootShotgun();
        
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        _ray = new Ray(_startPointRay.position, _camera.transform.forward);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            _tempPointImpact = Instantiate(_prefab);
            _tempPointImpact.transform.position = _raycastHit.point;
        }

        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.blue);
    }

    private void ShootShotgun()
    {
        for (int i = 0; i < 5; i++)
        {
            _ray = new Ray(_startPointRay.position, _camera.transform.forward);

            if (Physics.Raycast(_ray, out _raycastHit))
            {
                _tempPointImpact = Instantiate(_prefab);
                _tempPointImpact.transform.position = _raycastHit.point;
            }
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.blue);
    }
}