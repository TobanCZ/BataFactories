using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SellBoticky : MonoBehaviour
{
    public GameObject[] bootTypes;
    public int[] Price;

    GameObject gamecontroller;
    MoneyController money;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        money = gamecontroller.GetComponent<MoneyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Item")
        {
            for (int i = 0; i < bootTypes.Length; i++)
            {
                if (bootTypes[i].name == collision.gameObject.name.Replace("(Clone)", ""))
                {
                    money.Money += Price[i];
                    Destroy(collision.transform.gameObject);
                    break;
                }
            }


        }
    }
}
