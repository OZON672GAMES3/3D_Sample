using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const string _lineRotationY = "Mouse Y";
    private const string _lineRotationX = "Mouse X";

    [SerializeField] private float _sensetivity;

    private int _minRotation = -45;
    private int _maxRotation = 45;
    private float _mouseY;
    private float _mouseX;
    private float _rotationX = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis(_lineRotationX);
        _mouseY = Input.GetAxis(_lineRotationY);
        
        transform.parent.Rotate(Vector3.up * (_mouseX * (_sensetivity * Time.deltaTime)));
        
        _rotationX -= _mouseY * _sensetivity * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, _minRotation, _maxRotation);
        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}