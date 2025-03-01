using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private PointImpact _pointImpactPrefab;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _startPoint;
    
    private Ray _ray;
    private RaycastHit _raycastHit;

    private Vector3 _aimPosition;
    
    private Camera _camera;
    private Projectile _tempProjectile;
    private PointImpact _temPointImpact;
    private float _distance;

    private void Start()
    {
        _camera = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootLaser();
    }

    void ShootLaser()
    {
        _aimPosition = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        _ray = new Ray(_startPoint.position, _camera.transform.forward);

        if (Physics.Raycast(_ray, out _raycastHit))
        {
            _temPointImpact = Instantiate(_pointImpactPrefab);
            _temPointImpact.transform.position = _raycastHit.point;

            DrawLaserLine(_startPoint, _raycastHit);
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.green);
    }

    void DrawLaserLine(Transform startPoint, RaycastHit hit)
    {
        _tempProjectile = Instantiate(_projectile,
            Vector3.Lerp(startPoint.position, hit.point, 0.5f), transform.rotation);
        _tempProjectile.transform.localScale = new Vector3(_tempProjectile.transform.localScale.x,
            _tempProjectile.transform.localScale.y, hit.distance);
    }
}