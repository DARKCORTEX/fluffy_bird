using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private bool rotateXAxis;
    [SerializeField] private bool rotateYAxis;
    [SerializeField] private bool rotateZAxis;

    void Update()
    {
        transform.rotation = Quaternion.Euler(rotateXAxis?velocity*Time.time:0,rotateYAxis?velocity*Time.time:0,rotateZAxis?velocity*Time.time:0);
    }
}
