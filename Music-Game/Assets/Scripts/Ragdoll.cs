﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public GameObject NewS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().drag = GetComponent<Rigidbody>().mass;
        GetComponent<Rigidbody>().MovePosition(NewS.transform.position);
    }
}
