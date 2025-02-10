using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PointImpact : MonoBehaviour
{
    [SerializeField] private int _timeToDie;

    private void Start()
    {
        Destroy(gameObject, _timeToDie);
    }
}