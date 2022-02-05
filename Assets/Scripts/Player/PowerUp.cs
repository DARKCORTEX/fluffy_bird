using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private string starTag;
    [SerializeField] private bool powerUpON;
    [SerializeField] private float duration;
    [SerializeField] private Color baseColor;
    [SerializeField] private float rainbowThreshold;
    [SerializeField] private float playerPowerUpvelocity;
    private float playerNormalVelocity;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask objectToIgnore;
    

    void Start()
    {
        playerNormalVelocity = gameObject.GetComponent<Movement2D>().GetVelocity();
    }
    void Update()
    {
        if(powerUpON)
        {
            Invulnerable(true);
            VelocityUp();
            RainbowColor();
        }else
        {
            Invulnerable(false);
            VelocityDown();
            NormalColor();
        }
    }

    void RainbowColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.yellow,Color.blue,Mathf.PingPong(Time.time,rainbowThreshold));
    }
    void NormalColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = baseColor;
    }

    void VelocityUp()
    {
        gameObject.GetComponent<Movement2D>().SetVelocity(playerPowerUpvelocity);
    }

    void VelocityDown()
    {
        gameObject.GetComponent<Movement2D>().SetVelocity(playerNormalVelocity);
    }

    void Invulnerable(bool invulnerable)
    {
       Physics2D.IgnoreLayerCollision(7,6,invulnerable);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == starTag)
        {
            PowerUpStartActivated();
            col.gameObject.SetActive(false);
        }
    }

    public void PowerUpStartActivated()
    {
        StopAllCoroutines();
        powerUpON = true;
        StartCoroutine(DesactivatePowerUp());

    }

    IEnumerator DesactivatePowerUp()
    {
        yield return new WaitForSeconds(duration);
        powerUpON = false;
    }
}
