using UnityEngine;

namespace DefaultNamespace.Pong3D
{
    public class Racket3D : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * (_speed * Time.deltaTime));

            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * (_speed * Time.deltaTime));
            
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, _leftBorder.position.x, _rightBorder.position.x);
            transform.position = pos;
        }
    }
}