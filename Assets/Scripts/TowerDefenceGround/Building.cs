using UnityEngine;

namespace TowerDefenceGround
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Vector2Int _buildingSize;
        [SerializeField] private Color _gizmosColor;
        [SerializeField] private MeshRenderer _meshRenderer;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < _buildingSize.x; i++)
            {
                for (int j = 0; j < _buildingSize.y; j++)
                {
                    Gizmos.color = _gizmosColor;
                    Gizmos.DrawCube(transform.position + new Vector3(i, 0, j),
                        new Vector3(1, 0.1f, 1));
                }
            }
        }

        public void SetColor(bool makeConstruct)
        {
            _meshRenderer.material.color = makeConstruct ? Color.green : Color.red;
        }

        public void SetNormalColor()
        {
            _meshRenderer.material.color = Color.white;
        }

        public int TakeSizeX()
        {
            return _buildingSize.x;
        }

        public int TakeSizeY()
        {
            return _buildingSize.y;
        }
        
        public void RotateSize()
        {
            int temp = _buildingSize.x;
            _buildingSize.x = _buildingSize.y;
            _buildingSize.y = temp;
        }
    }
}