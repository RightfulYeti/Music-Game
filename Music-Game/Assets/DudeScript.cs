using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    //bool Throw = false;
    //public GameObject PlayerRef;
    Ray ray;
    float ray_length = 0.5f;
    public int force = 800;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerRef = GameObject.Find("Player");
        ray = new Ray(transform.position, Vector3.down * ray_length);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Throw)
        //{
        //    ApplyForce(transform);
        //    Throw = false;
        //}
            
    }

    private void FixedUpdate() {
        RaycastHit hit;
        ray = new Ray(transform.position, new Vector3(transform.position.x,-ray_length));
        if (Physics.Raycast(ray, out hit, ray_length)) {
            if(hit.collider.gameObject.tag == "Umbrella") {
                Debug.DrawLine(transform.position, new Vector3(transform.position.x, -ray_length), Color.green);
                Vector2 BounceDir = Vector2.Reflect(ray.direction, hit.normal);
                BounceDir = BounceDir.normalized;
                ApplyForce(transform, BounceDir);

            }
            else {
                Debug.DrawLine(transform.position, new Vector3(transform.position.x, -ray_length), Color.yellow);
            }
        }


    }

    private void ApplyForce(Transform target, Vector3 bounceDirection)
    {
        foreach (Transform t in target)
        {
            Rigidbody r = t.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddForce(bounceDirection * force);
                //if (PlayerRef.transform.position.x <= r.transform.position.x)
                //{
                //    r.AddForce(50, 100, 0);
                //    // r.AddForce(r.transform.right + transform.up * 1000.0f);
                //    //r.AddExplosionForce(300, transform.position + transform.right, 1000f, 20f);
                //}
                //else
                //{
                //    r.AddForce(-50, 100, 0);
                //    //r.AddForce(r.transform.right + transform.up * -1 * 1000.0f);
                //   // r.AddExplosionForce(300, transform.position + transform.right * -1, 1000f, 20f);
                //}
            }
            ApplyForce(t, bounceDirection);
        }
    }
}
