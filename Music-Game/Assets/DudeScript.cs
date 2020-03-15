using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    float ray_length = 0.8f;
    public int force = 800;
    bool hasBounced = false;

    private void FixedUpdate() {
        Vector3 down = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        RaycastHit hit;
        Ray ray = new Ray(transform.position, down);

        if (Physics.Raycast(ray, out hit, ray_length)) {
            if(hit.collider.gameObject.tag == "Umbrella") {

                if (!hasBounced) {
                    Vector3 BounceDir = Vector3.Reflect(ray.direction, hit.normal);
                    BounceDir = BounceDir.normalized;
                    float wind = Random.Range(-0.2f, 0.25f);
                    BounceDir = new Vector3(BounceDir.x + wind, BounceDir.y, 0);
                    ApplyForce(transform, BounceDir);
                    hasBounced = true;
                }

            }
            else {
                hasBounced = false;
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
                r.AddForce(bounceDirection * force, ForceMode.Acceleration);
            }
            ApplyForce(t, bounceDirection);
        }
    }
}
