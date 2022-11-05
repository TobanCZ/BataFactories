using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject[] items;
    public int[] itemsCount;
    public GameObject outputItem;
    public int proccestime;
    public Transform outputTransform;

    

    int[] currentItems;
    float timeLeft = 0;
    bool isRunning = false;


    void Start()
    {
        currentItems = new int[itemsCount.Length];
    }

    void Update()
    {
        if(isRunning)
        {
            timeLeft -= Time.deltaTime;

            if(timeLeft < 0)
            {
               
                Finish();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Item" && isRunning == false)
        {
            for(int i =0;i < items.Length; i++)
            {
                if (items[i].name == collision.gameObject.name.Replace("(Clone)","") && currentItems[i] != itemsCount[i])
                {
                    currentItems[i]++;
                    Destroy(collision.transform.gameObject);
                    CheckAllItems();
                }
            }
            
            
        }
    }

    void CheckAllItems()
    {
        for(int i = 0;i < itemsCount.Length; i++)
        {
            if (itemsCount[i] != currentItems[i])
            {
                return;
            }
        }

        StartMachine();
    }

    void StartMachine()
    {
        isRunning = true;
        timeLeft = proccestime;
    }

    void Finish()
    {
        Vector3 pos = outputTransform.position;
        pos.z = -5;
        Instantiate(outputItem, pos, outputItem.transform.rotation);

        currentItems = new int[itemsCount.Length];
        isRunning = false;
    }
}
