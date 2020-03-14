using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    bool Throw = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Throw)
            ApplyForce(transform);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        Collider myCollider = collision.contacts[0].thisCollider;
        //foreach(ContactPoint Col in collision.contacts)
        //{
        //    ApplyForce(Col.thisCollider.transform);
        //    Throw = true;
        //}
        Throw = true;
    }

    private void ApplyForce(Transform target)
    {
        foreach (Transform t in target)
        {
            Rigidbody r = t.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(30, transform.position + transform.right, 10f, 2f);
            }
            ApplyForce(t);
        }
    }
}
