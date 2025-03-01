using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static event Action Showed;
    public event Action<string> ShowedText;

    public static event Action ChangeColor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Showed?.Invoke();
            /*
            if (Showed.GetInvocationList().Length > 0) // проверка на слушателя (выше сокращённый вариант)
                Showed.Invoke();
                */
        }

        if (Input.GetKeyDown(KeyCode.F))
            ShowedText?.Invoke("event-2");
        
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeColor?.Invoke();
    }
}