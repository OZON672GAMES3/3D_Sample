using UnityEngine;

namespace TowerDefenceGround
{
    public class BuildingGrid : MonoBehaviour
    {
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private Camera _camera;
        [SerializeField] private KeyCode _placeBuilding = KeyCode.Mouse0;

        private Building[,] _grid; // сеткая которая содержит наличие или отстутвие здания
        private Building _tempBuilding;

        private Ray _ray;
        private Plane _ground;
        private Vector3 _worldPosition;

        private bool _makeConstruct;
        private int _positionX;
        private int _positionZ;
        private int _sizeX;
        private int _sizeY;

        private void Awake()
        {
            _grid = new Building[_gridSize.x, _gridSize.y];
        }
        
        private void Update()
        {
            if (_tempBuilding)
            {
                _ground = new Plane(Vector3.up, Vector3.zero);
                _ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (_ground.Raycast(_ray, out float position))
                {
                    _worldPosition = _ray.GetPoint(position);

                    _positionX = Mathf.RoundToInt(_worldPosition.x);
                    _positionZ = Mathf.RoundToInt(_worldPosition.z);
                    
                    _makeConstruct = true;
                    
                    if (_positionX < 0 || _positionX > _gridSize.x - _tempBuilding.TakeSizeX())
                        _makeConstruct = false;
                    
                    if (_positionZ < 0 || _positionZ > _gridSize.y - _tempBuilding.TakeSizeY())
                        _makeConstruct = false;
                    
                    if (_makeConstruct)
                        _makeConstruct = IsAreaEmpty(_positionX, _positionZ, _tempBuilding.TakeSizeX(),
                            _tempBuilding.TakeSizeY());
                    
                    Rotation();

                    _tempBuilding.transform.position = new Vector3(_positionX, 0, _positionZ);
                    _tempBuilding.SetColor(_makeConstruct);

                    if (_makeConstruct && Input.GetKeyDown(_placeBuilding))
                        PlaceBuilding(_positionX, _positionZ);
                }
            }
        }

        private bool IsAreaEmpty(int placeX, int placeY, int sizeX, int sizeY)
        {
            for (int i = 0; i < sizeX; i++)
            for (int j = 0; j < sizeY; j++)
                if (_grid[placeX + i, placeY + j])
                    return false;
            
            return true;
        }

        private void PlaceBuilding(int placeX, int placeY)
        {
            _sizeX = _tempBuilding.TakeSizeX();
            _sizeY = _tempBuilding.TakeSizeY();

            for (int i = 0; i < _sizeX; i++)
            for (int j = 0; j < _sizeY; j++)
                _grid[placeX + i, placeY + j] = _tempBuilding;
            
            _tempBuilding.SetNormalColor();
            _tempBuilding = null;
        }

        public void StartPlaceBuilding(Building prefabBuilding)
        {
            if (_tempBuilding)
                Destroy(_tempBuilding.gameObject);
            
            _tempBuilding = Instantiate(prefabBuilding);
        }
        
        private void Rotation()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _tempBuilding.transform.Rotate(0, -90f, 0);
                _tempBuilding.RotateSize();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _tempBuilding.transform.Rotate(0, 90f, 0);
                _tempBuilding.RotateSize();
            }

            if (Input.GetKeyDown(KeyCode.Z))
                _tempBuilding.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}