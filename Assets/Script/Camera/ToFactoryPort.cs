using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFactoryPort : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] teleportPositions;

    public GameObject Menu;
    public GameObject BuildMenu;


    GameObject gamecontroller;
    MoneyController money;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        money = gamecontroller.GetComponent<MoneyController>();
    }

    void Update()
    {
        
    }

    public void teleport(int place)
    {

        
            transform.position = teleportPositions[place].position;
            Menu.active = false;
            BuildMenu.active = true;
        
        
    }

    public void Back()
    {
        Menu.active = true;
        BuildMenu.active = false;
    }
}
