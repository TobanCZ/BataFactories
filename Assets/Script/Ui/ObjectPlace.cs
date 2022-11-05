using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class ObjectPlace : MonoBehaviour
{
    public GameObject[] objects;
    public int[] objectCost;
    public LayerMask RayLayers;
    public GameObject CannotBuildHereObject;
    public bool inBuilding = false;

    GameObject current = null;
    int currentitemNum = 0;
    bool drag = false;

    public AudioSource place;
    public AudioSource destroy;

    public GameObject Selector;


    int currentBoltRotation = 0;

    public GameObject currentFactory;

    GameObject gamecontroller;
    MoneyController money;

    bool ne = false;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        money = gamecontroller.GetComponent<MoneyController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBoltRotation -= 90;
            current.transform.rotation = Quaternion.AngleAxis(currentBoltRotation, new Vector3(0, 0, 1));
        }
    }

    void FixedUpdate()
    {
        if (drag && !ne)
        {
            Selector.active = false;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            worldPosition.x = (float)(Math.Round(worldPosition.x));
            worldPosition.y = (float)(Math.Round(worldPosition.y));
            current.transform.position = worldPosition;


            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000f, RayLayers);

            if (hit.collider == null || hit.transform.gameObject.layer == 8)
            {
                CannotBuildHereObject.active = true;

            }
            else
            {
                CannotBuildHereObject.active = false;

                if (Input.GetMouseButton(0) && hit.transform.gameObject.layer != 11)
                {
                    current.layer = 11;
                    GameObject ObjectToSpawn = objects[currentitemNum];
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z = -5;
                    current = Instantiate(ObjectToSpawn, pos, Quaternion.AngleAxis(currentBoltRotation, new Vector3(0, 0, 1)));
                    current.layer = 0;
                    money.Money -= objectCost[currentitemNum];
                    place.Play();
                }
                else
                if (Input.GetMouseButton(1) && hit.transform.gameObject.layer == 11)
                {
                    for(int i = 0; i < objects.Length;i++)
                    {
                        if (objects[i].name == hit.transform.gameObject.name.Replace("(Clone)", ""))
                        {
                            money.Money += objectCost[i] / 2;
                            break;
                        }
                    }
                    Destroy(hit.transform.gameObject);
                    destroy.Play();
                    
                }
            }
        }
        else
        {


            if (Input.GetMouseButton(0))
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000f, RayLayers);

                if (hit.collider != null && hit.transform.gameObject.name.Replace("(Clone)", "") == "Zprac boty")
                {
                    Selector.active = true;
                    currentFactory = hit.transform.gameObject;
                }
            }
        }
    }

    public void MouseClick(int objectNum)
    {
        ne = false;
        if (drag == false)
        {
            currentitemNum = objectNum;
            GameObject ObjectToSpawn = objects[currentitemNum];
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            current = Instantiate(ObjectToSpawn, worldPosition, Quaternion.AngleAxis(currentBoltRotation,new Vector3(0,0,1)));
            current.layer = 0;
            drag = true;
            inBuilding = true;
        }
        if(drag == true)
        {
            currentitemNum = objectNum;
            Destroy(current);
            GameObject ObjectToSpawn = objects[currentitemNum];
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            current = Instantiate(ObjectToSpawn, worldPosition, Quaternion.AngleAxis(currentBoltRotation, new Vector3(0, 0, 1)));
            current.layer = 0;
            drag = true;
            inBuilding = true;
        }
    }

    public void StopPls()
    {
        ne = true;
    }

    public void DestrotItem()
    {
        if (drag)
        {
            drag = false;
            inBuilding = false;
            Destroy(current);
            CannotBuildHereObject.active = false;
            
        }
        Selector.active = false;
    }
}
