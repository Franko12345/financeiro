using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrinha : MonoBehaviour
{
    float vel = 8   ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0,vel*Time.deltaTime, 0);
        if (transform.position.y > 3.5)
            transform.position = new Vector3(transform.position.x , -4.17f , 0);
    }
}
