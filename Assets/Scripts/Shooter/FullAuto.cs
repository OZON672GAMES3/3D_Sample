using UnityEngine;

public class FullAuto : MonoBehaviour
{
    [SerializeField] private PointImpact _prefab;
    [SerializeField] private Transform _startPointRay;
    [SerializeField] private float _fireRate;

    private RaycastHit _raycastHit;
    private Ray _ray;
    
    private Camera _camera;
    private PointImpact _tempPointImpact;
    
    private float _nextFireTime;

    private void Start()
    {
        _camera = GetComponentInParent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            ShootFullAuto();
        }
    }

    private void ShootFullAuto()
    {
        _ray = new Ray(_startPointRay.position, _camera.transform.forward);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            _tempPointImpact = Instantiate(_prefab);
            _tempPointImpact.transform.position = _raycastHit.point;
        }

        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.blue);
    }
}