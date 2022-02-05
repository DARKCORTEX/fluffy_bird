using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float distanceBetweenGrounds;
    [SerializeField] private GameObject lastGround;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            if(lastGround == null)
            {
                lastGround = col.gameObject;
                return;
            }

            if(lastGround != col.gameObject)
            {
                lastGround.transform.localPosition = new Vector3(col.gameObject.transform.position.x + distanceBetweenGrounds,lastGround.transform.localPosition.y,0);
                lastGround = col.gameObject;
            }
        }
    }
}
