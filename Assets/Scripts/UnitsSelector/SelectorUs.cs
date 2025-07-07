using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.UnitsSelector
{
    public class SelectorUs : MonoBehaviour
    {
        [SerializeField] private Texture _boxSelector;

        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private bool _isSelected;
        
        private List<MoverUs> _allUnits;
        private List<MoverUs> _selectedUnits;

        private void Start()
        {
            _allUnits = new List<MoverUs>(FindObjectsOfType<MoverUs>());
            _selectedUnits = new List<MoverUs>();
        }

        private void Update()
        {
            HandleSelection();
            HandleMovement();
        }

        private void HandleSelection()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPosition = Input.mousePosition;
                _isSelected = true;
            }

            if (_isSelected)
            {
                _endPosition = Input.mousePosition;

                if (Input.GetMouseButtonUp(0))
                {
                    _isSelected = false;
                    SelectUnitsRect();
                }
            }
        }

        private void HandleMovement()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 center = hit.point;

                    int count = _selectedUnits.Count;
                    int rowSize = Mathf.CeilToInt(Mathf.Sqrt(count));
                    float spacing = 2.0f;

                    for (int i = 0; i < count; i++)
                    {
                        int row = i / rowSize;
                        int col = i % rowSize;

                        float offsetX = (col - rowSize / 2f) * spacing;
                        float offsetZ = (row - rowSize / 2f) * spacing;

                        Vector3 targetPos = center + new Vector3(offsetX, 0, offsetZ);
                        _selectedUnits[i].SetTargetVector(targetPos);
                    }
                }
            }
        }

        private void OnGUI()
        {
            if (_isSelected)
            {
                var rect = GetScreenRect(_startPosition, _endPosition);
                GUI.DrawTexture(rect, _boxSelector);
            }
        }

        private void SelectUnitsRect()
        {
            Rect selectionRect = GetScreenRect(_startPosition, _endPosition);
            _selectedUnits.Clear();

            foreach (MoverUs unit in _allUnits)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);

                if (selectionRect.Contains(new Vector2(screenPos.x, Screen.height - screenPos.y)))
                {
                    unit.Select();
                    _selectedUnits.Add(unit);
                }
                else
                {
                    unit.Deselect();
                }
            }
        }

        private Rect GetScreenRect(Vector3 p1, Vector3 p2)
        {
            float x = Mathf.Min(p1.x, p2.x);
            float y = Mathf.Min(Screen.height - p1.y, Screen.height - p2.y);
            float width = Mathf.Abs(p2.x - p1.x);
            float height = Mathf.Abs(p2.y - p1.y);

            return new Rect(x, y, width, height);
        }
    }
}