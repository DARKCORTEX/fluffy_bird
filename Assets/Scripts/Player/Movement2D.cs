using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    private float directionX;
    [SerializeField] private float velocity = 1;
    private Rigidbody2D rigid2D;


    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerIsAlive && !GameManager.instance.pause)
        {
            Movement();
        }
    }

    void Movement()
    {
        directionX = 0;
        //MoveLeft();
        MoveRight();
        rigid2D.velocity = new Vector2(directionX * velocity,rigid2D.velocity.y);
    }
    void MoveLeft()
    {
        directionX = -1;
    }
    void MoveRight()
    {
        directionX = 1;
    }

    public float GetVelocity()
    {
        return velocity;
    }
    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }
}
