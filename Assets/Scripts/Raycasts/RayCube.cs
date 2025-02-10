using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    
    public void ChangeColor()
    {
       _meshRenderer.material.color = Random.ColorHSV(); 
    }
}