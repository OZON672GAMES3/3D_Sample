using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private WeatherStation _weatherStation;
    [SerializeField] private Text _text;
    
    void OnEnable()
    {
        _weatherStation.TemperatureChanged += GetTemperature;
    }

    private void OnDisable()
    {
        _weatherStation.TemperatureChanged -= GetTemperature;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void GetTemperature()
    {
        _text.text = $"Current temperature: {Random.Range(20, 30)}\u00b0C";
        Debug.Log($"Current temperature: {Random.Range(20, 30)}\u00b0C");
    }
}