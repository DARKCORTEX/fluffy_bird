using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float threshold;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool lockXAxis;
    [SerializeField] private bool lockYAxis;
    [SerializeField] private bool lockZAxis;

    void Update()
    {
        FollowTarget();
    }

    public void FollowTarget()
    {
       Vector3 positionWithOffset = new Vector3(lockXAxis?offset.x:target.transform.position.x + offset.x,lockYAxis?offset.y:target.transform.position.y + offset.y,lockZAxis?offset.z:target.transform.position.z + offset.z);
       transform.position = Vector3.Lerp(transform.position,positionWithOffset,threshold);
    }
}
