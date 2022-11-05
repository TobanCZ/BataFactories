using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public InputField inputKuze;
    public InputField inputGuma;

    GameObject gamecontroller;
    MoneyController money;
    ZasobyController zasoby;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        money = gamecontroller.GetComponent<MoneyController>();
        zasoby = gamecontroller.GetComponent<ZasobyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputKuze.text != "" && Convert.ToInt32(inputKuze.text) > Math.Round((money.Money / 199)))
        {
            inputKuze.text = Math.Floor((money.Money / 199)).ToString();
        }

        if (inputGuma.text != "" && Convert.ToInt32(inputGuma.text) > Math.Round((money.Money / 199)))
        {
            inputGuma.text = Math.Floor((money.Money / 99)).ToString();
        }
    }

    public void BuyKuze()
    {
        money.Money -= Convert.ToInt32(inputKuze.text) * 199;
        zasoby.Kuze += Convert.ToInt32(inputKuze.text);
    }

    public void BuyGuma()
    {
        money.Money -= Convert.ToInt32(inputGuma.text) * 99;
        zasoby.Guma += Convert.ToInt32(inputGuma.text);
    }
}
