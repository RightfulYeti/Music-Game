using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    bool Throw = false;
    public GameObject PlayerRef;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Throw)
        {
            ApplyForce(transform);
            Throw = false;
        }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.contacts[0].thisCollider;
        Throw = true;
    }

    private void ApplyForce(Transform target)
    {
        foreach (Transform t in target)
        {
            Rigidbody r = t.GetComponent<Rigidbody>();
            if (r != null)
            {
                print("Force!");
                if (PlayerRef.transform.position.x <= r.transform.position.x)
                {
                    r.AddForce(50, 100, 0);
                    // r.AddForce(r.transform.right + transform.up * 1000.0f);
                    //r.AddExplosionForce(300, transform.position + transform.right, 1000f, 20f);
                }
                else
                {
                    r.AddForce(-50, 100, 0);
                    //r.AddForce(r.transform.right + transform.up * -1 * 1000.0f);
                   // r.AddExplosionForce(300, transform.position + transform.right * -1, 1000f, 20f);
                }
            }
            ApplyForce(t);
        }
    }
}
