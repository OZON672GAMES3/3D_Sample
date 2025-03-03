using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeatherStation : MonoBehaviour
{
    public event Action TemperatureChanged;

    [SerializeField] private float _delay = 5f;

    void Start()
    {
        StartCoroutine(GetTemperature(_delay));
    }

    IEnumerator GetTemperature(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            TemperatureChanged?.Invoke();
            
            yield return wait;
        }
    }
}