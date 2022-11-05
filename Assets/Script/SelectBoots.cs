using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBoots : MonoBehaviour
{
    public GameObject[] boots;
    public GameObject[] Itemsboots;
    public GameObject Selector;
    public int bootstype;
    public int[,] factoryparm = { { 1, 1 }, { 2, 1 }, { 2, 2 }, { 3, 3 } };


GameObject gamecontroller;
    ObjectPlace getFactory;
    Factory factory;
    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        getFactory = gamecontroller.GetComponent<ObjectPlace>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        factory = getFactory.currentFactory.GetComponent<Factory>();
        for (int i = 0; i < boots.Length; i++)
        {
            if (factory.outputItem.name.Replace("(Clone)","") == Itemsboots[i].name)
            {
                
                Selector.transform.position = boots[i].transform.position;
                break;
            }
        }
    }

    public void Select(int type)
    {
        bootstype = type;
        factory.outputItem = Itemsboots[type];
        factory.itemsCount[0] = factoryparm[type,0];
        factory.itemsCount[1] = factoryparm[type, 1];
    }
}
