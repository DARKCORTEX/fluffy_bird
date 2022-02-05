using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropChance : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float dropChance;
    [SerializeField] private GameObject itemDrop;
    void Start()
    {
        DropResult();
    }

    public void DropResult()
    {
        if(Random.Range(0f,1f) <= dropChance)
        {
            itemDrop.SetActive(true);
        }
    }
}
