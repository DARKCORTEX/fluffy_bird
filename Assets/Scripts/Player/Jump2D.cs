using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump2D : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    [SerializeField] private float jumpforce = 1;
    [SerializeField] private bool enableMiniJump;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    [SerializeField] private bool onGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float collisionRadius = 0.25f;
    [SerializeField] private Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;
    [SerializeField] private int numberOfJumps;
    private int jumpCount;

    [SerializeField] private bool infiniteJumps;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(GameManager.instance.playerIsAlive && !GameManager.instance.pause)
        {
            IsOnGround();
            if(onGround)
            {
                ResetJumpCount();
                Jump();
            }
            if(!onGround && jumpCount>0)
            {
                Jump();
            }
            if(enableMiniJump)
            {
                MiniJump();
            }
            IsInfinityJumps();  
        }
    }

    public void Jump()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x,jumpforce);
            jumpCount--;
        }
    }

    private void MiniJump()
    {
        if(rigid2D.velocity.y < 0)
        {
            rigid2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if(rigid2D.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rigid2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void IsOnGround()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,collisionRadius,groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColor;
        var pos = new Vector2[]{bottomOffset};

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }

    void ResetJumpCount()
    {
        if(rigid2D.velocity.y==0)
        {
            jumpCount = numberOfJumps;
        }
    }

    public void SetNumberOfJumps(int jumps)
    {
        numberOfJumps = jumps;
    }

    public int GetNumberOfJumps()
    {
        return numberOfJumps;
    }

    public void IsInfinityJumps()
    {
        if(infiniteJumps)
        {
            jumpCount = numberOfJumps;
        }
    }
}
