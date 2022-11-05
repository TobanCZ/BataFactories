using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Speed = 0;

    float x = 0;
    float y = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x,y) * Speed * Time.deltaTime, Space.Self);
    }
}
