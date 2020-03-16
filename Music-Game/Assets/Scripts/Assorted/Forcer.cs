using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public FixedJoint joint;
    bool hasCollided = false;
    public LayerMask WallLayer;
    // Start is called before the first frame update

    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "Dude")
        {
            if (!hasCollided)
            {
                foreach (Transform t in gameObject.transform.root.transform.gameObject.GetComponentsInChildren<Transform>())
                {
                    t.gameObject.layer = LayerMask.NameToLayer("Wall");
                }
                // creates joint
                joint = gameObject.AddComponent<FixedJoint>();
                // sets joint position to point of contact
                joint.anchor = other.contacts[0].point * 1.25f;
                // conects the joint to the other object
                joint.connectedBody = other.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                // Stops objects from continuing to collide and creating more joints
                joint.enableCollision = true;
                hasCollided = true;
                Transform[] allChildren = GetComponentsInChildren<Transform>();
                foreach (Transform child in allChildren)
                {
                    if (child.GetComponent<Collider>())
                        child.GetComponent<Collider>().enabled = false;
                }
                GameObject.Find("mixamorig:Hips").gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }
    private void ignoreCollision(Transform target)
    {
        foreach (Transform t in target)
        {
            Collider col = t.gameObject.GetComponent<Collider>();
            if (col != null)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), t.gameObject.GetComponent<Collider>(), true);
            }
            ignoreCollision(t);
        }
    }
}
