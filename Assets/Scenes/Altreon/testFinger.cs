﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFinger : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(-transform.up * speed, ForceMode.VelocityChange);
        //transform.position.y -= 20;
    }
}
