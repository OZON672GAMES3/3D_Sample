using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.LightPractice
{
    public class ObjWithCollider : MonoBehaviour
    {
        [SerializeField] private List<HoverLight> _lights;
        [SerializeField] private ScoreBoardLight _scoreBoard;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                DetectClick();
        }

        private void DetectClick()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider)
            {
                OnMouseDownObjects obj = hit.collider.gameObject.GetComponent<OnMouseDownObjects>();

                if (obj && !obj.IsFind)
                {
                    EnableMatchingLight(obj.ObjectId);
                    _scoreBoard.AddScore(obj.ObjectScore);
                    obj.Find();
                }
            }
        }

        private void EnableMatchingLight(string objId)
        {
            foreach (HoverLight light in _lights)
                if (light.LightId == objId)
                    light.EnableLight();
        }
    }
}