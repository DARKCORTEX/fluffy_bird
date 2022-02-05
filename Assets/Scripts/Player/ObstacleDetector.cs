using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField] private bool player;
    [SerializeField] private bool obstacleDestroyer;
    [SerializeField] private string obstacleTag;
    [SerializeField] private string groundTag;
    [SerializeField] private CharacterScore score;
    
    void Start()
    {
        score = GameObject.FindObjectOfType<CharacterScore>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == obstacleTag || col.gameObject.tag == groundTag)
        {
            if(player)
            {
                GameManager.instance.playerIsAlive = false;
                score.SaveHighScore();
            } 
        }    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == obstacleTag)
        {
            if(obstacleDestroyer)
            {
                DestroyObstacle(col.gameObject.transform.parent.gameObject);
            }
        }
    }

    public void DestroyObstacle(GameObject obj)
    {
        if(obj != null)
        {
            Destroy(obj);
        }
    }

}
