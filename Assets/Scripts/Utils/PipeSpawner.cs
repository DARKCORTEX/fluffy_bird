using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private bool canSpawnNewObstacle;
    [SerializeField] private float spawnLimitUp;
    [SerializeField] private float spawnLimitDown;
    [SerializeField] private float distanceBetweenPipes;
    [SerializeField] private GameObject lastPipe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawnNewObstacle)
        {
            SpawnObstacle();
            canSpawnNewObstacle = false;
        }
    }

    void SpawnObstacle()
    {
        float high = Random.Range(spawnLimitDown,spawnLimitUp);
        GameObject obstacle = Instantiate(obstaclePrefab,new Vector3(lastPipe.transform.position.x + distanceBetweenPipes,high,0),Quaternion.identity) as GameObject;
        lastPipe = obstacle;
    }

    public void CanSpawn()
    {
        canSpawnNewObstacle = true;
    }
}
