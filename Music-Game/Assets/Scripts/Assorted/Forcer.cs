﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public FixedJoint joint;
    bool hasCollided = false;
    bool hasCollidedWithDude = false;
    public LayerMask WallLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall")
        {
            if (!hasCollided)
            {
                // creates joint
                joint = gameObject.AddComponent<FixedJoint>();
                // sets joint position to point of contact
                joint.anchor = other.contacts[0].point * 1.25f;
                // conects the joint to the other object
                joint.connectedBody = other.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                // Stops objects from continuing to collide and creating more joints
                joint.enableCollision = true;
                hasCollided = true;
            }
        }
        else if (other.transform.tag == "Dude") {
            // creates joint
            joint = gameObject.AddComponent<FixedJoint>();
            // sets joint position to point of contact
            joint.anchor = other.contacts[0].point * 1.25f;
            // conects the joint to the other object
            joint.connectedBody = other.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = true;
        }
    }
}
