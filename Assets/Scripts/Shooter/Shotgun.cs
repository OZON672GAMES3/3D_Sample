using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private PointImpact _prefab;
    [SerializeField] private Transform _startPointRay;

    private RaycastHit _raycastHit;
    private Ray _ray;
    
    private Camera _camera;
    private PointImpact _tempPointImpact;
    
    private void Start()
    {
        _camera = GetComponentInParent<Camera>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootShotgun();
    }
    
    private void ShootShotgun()
    {
        for (int i = 0; i < 5; i++)
        {
            _ray = new Ray(_startPointRay.position, _camera.transform.forward += GetRandomVector());

            if (Physics.Raycast(_ray, out _raycastHit))
            {
                _tempPointImpact = Instantiate(_prefab);
                _tempPointImpact.transform.position = _raycastHit.point;
            }
        }
        
        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.blue);
    }

    private Vector3 GetRandomVector()
    {
        return new Vector3(
            Random.Range(0.05f, -0.05f),
            Random.Range(0.05f, -0.05f),
            Random.Range(0.05f, -0.05f));
    }
}