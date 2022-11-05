using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public Text moneyText;
    public float Money;

    public GameObject gameover;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = Money.ToString();
        if(Money < 0)
        {
            gameover.active = true;
        }
    }
}
