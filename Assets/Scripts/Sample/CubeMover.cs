using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private void Awake()
    {
        // выполниться один раз при создании (инициализации)
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        // при влючении
        Debug.Log("OnEnable");
    }
    
    private void Start()
    {
        Debug.Log("Start");
    }

    private void FixedUpdate()
    {
        // срабатывает фиксированное количство раз в секунду
    }

    private void OnTriggerEnter() // OnColliderEnter
    {
        // выполняется единожды при попадании в зону триггера
    }

    private void OnTriggerStay() // OnColliderStay
    {
        // выполняется постоянно при нахождении в зоне триггера
    }

    private void OnTriggerExit() // OnColliderExit
    {
        // выполняется один раз при выходе из триггера
    }

    private void Update()
    {
        // срабатывает каждый кадр
        
    }

    private void LateUpdate()
    {
        // после обработки всех физических и логических вычислений 
    }
    
    

    private void OnDisable()
    {
        // при выключении
    }

    
}