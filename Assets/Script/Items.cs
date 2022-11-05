using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int Speed;

    public bool isMoving = false;

    public GameObject gamecontroller;

    ObjectPlace objectplace;

    bool detekceidk = false;

    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        objectplace = gamecontroller.GetComponent<ObjectPlace>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && objectplace.inBuilding == false)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.gameObject.tag == "Pas")
        {
            isMoving = true;
            Quaternion bolRot = collision.transform.gameObject.transform.rotation;
            transform.rotation = bolRot;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.transform.gameObject.tag == "ItembcsBourak")
        {
            isMoving = false;
            detekceidk = true;
        }
        else if (collision.transform.gameObject.tag == "Factory")
        {
            isMoving = false;
            detekceidk = true;
        }
        else if (collision.transform.gameObject.tag == "Pas" && detekceidk == false)
        {
            isMoving = true;
            Quaternion bolRot = collision.transform.gameObject.transform.rotation;
            transform.rotation = bolRot;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "ItembcsBourak")
        {
            isMoving = true;
            detekceidk = false;
        }
        else if (collision.transform.gameObject.tag == "Factory")
        {
            isMoving = true;
            detekceidk = false;
        }
        else if (collision.transform.gameObject.tag == "Pas")
        {
            isMoving = false;
        }
        
    }
}
