using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Plane _plane;
    
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        Plane.Showed += Show;
        _plane.ShowedText += Show2;
        Plane.ChangeColor += ChangeColor;
    }

    void OnDisable()
    {
        Plane.Showed -= Show;
        _plane.ShowedText -= Show2;
        Plane.ChangeColor -= ChangeColor;
    }

    void Show()
    {
        Debug.Log("event-1");
    }

    void Show2(string text)
    {
        Debug.Log(text);
    }

    void ChangeColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}