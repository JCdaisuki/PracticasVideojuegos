using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation")]
    public bool x;
    public bool y;
    public bool z;

    [Header("Config.")]
    public float speed = 1;

    private void Update()
    { 
        float rotationX = x ? Time.deltaTime : 0;
        float rotationY = y ? Time.deltaTime : 0;
        float rotationZ = z ? Time.deltaTime : 0;

        transform.Rotate(rotationX * speed, rotationY * speed, rotationZ * speed);
    }
}
