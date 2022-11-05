using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZasobyUpdate : MonoBehaviour
{
    public Text KuzeCount;
    public Text GumaCount;

    GameObject gamecontroller;
    ZasobyController zasoby;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        zasoby = gamecontroller.GetComponent<ZasobyController>();
    }

    // Update is called once per frame
    void Update()
    {
        KuzeCount.text = zasoby.Kuze.ToString();
        GumaCount.text = zasoby.Guma.ToString();
    }
}
