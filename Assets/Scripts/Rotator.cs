using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float minSpeed = 0;
    public float maxSpeed = 1000;

    public void Rotate(float t)
    {
        var speed = Mathf.Lerp(minSpeed, maxSpeed, t);
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
