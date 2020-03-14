using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public FixedJoint joint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.T))
        //{
            //AddForceAtAngle(10, 90);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        //if (other.transform.tag == "Thing")
        //{
        //    //AddForceAtAngle(100, Vector3.Angle(other.transform.position, transform.position)-45);
        //    Vector3 direction = transform.position - other.transform.position;
        //    GetComponent<Rigidbody2D>().AddRelativeForce(direction * 2500);
        //    print(Vector3.Angle(other.transform.position, transform.position)-45);
        //}
        if (other.transform.tag == "Wall")
        {
            // creates joint
            foreach (Transform child in transform.root.transform)
            {
                if (child.GetComponent<Forcer>())
                {
                    Destroy(child.gameObject.GetComponent<Rigidbody2D>());
                    Destroy(child.gameObject.GetComponent<HingeJoint2D>());
                    child.GetComponent<Forcer>().joint = gameObject.AddComponent<FixedJoint>();
                }
            }
            // sets joint position to point of contact
            joint.anchor = other.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = other.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = false;
            print("Stuck");
        }
    }
}
