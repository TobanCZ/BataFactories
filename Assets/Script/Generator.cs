using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int timeCycle;
    public GameObject outputItem;
    public Transform outputPosition;

    public string type;

    float timeLeft = 0;
    public bool isRunning = false;

    int zasoby;

    GameObject gamecontroller;

    ObjectPlace objectplace;
    ZasobyController zasobycontroller;

    void Start()
    {
        timeLeft = timeCycle;
        gamecontroller = GameObject.Find("GameController");
        objectplace = gamecontroller.GetComponent<ObjectPlace>();
        zasobycontroller = gamecontroller.GetComponent<ZasobyController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(type == "Kuze")
        {
            zasoby = zasobycontroller.Kuze;
        }
        else if(type == "Guma")
        {
            zasoby = zasobycontroller.Guma;
        }

        if (isRunning && objectplace.inBuilding == false && zasoby != 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                Generate();
                timeLeft = timeCycle;
                if (type == "Kuze")
                {
                    zasobycontroller.Kuze--;
                }
                else if (type == "Guma")
                {
                    zasobycontroller.Guma--;
                }

            }
        }
    }

    void Generate()
    {
        Vector3 pos = outputPosition.position;
        pos.z = -5;
        Instantiate(outputItem, pos, outputItem.transform.rotation);
    }
}
