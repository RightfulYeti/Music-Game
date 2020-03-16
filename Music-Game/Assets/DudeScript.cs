using UnityEngine;

public class DudeScript : MonoBehaviour
{
    float ray_length = 1.0f;
    public int force = 800;
    bool hasBounced = false;

    private void Start() {
        foreach (Transform t in transform.root.transform) {
            Physics.IgnoreCollision(GetComponent<Collider>(), t.gameObject.GetComponent<Collider>(), true);
        }
    }

    private void FixedUpdate() 
    {
        Vector3 down = new Vector3(transform.position.x, transform.position.y - ray_length, transform.position.z);
        RaycastHit hit;
        Ray ray = new Ray(transform.position, down);

        Debug.DrawRay(ray.origin, ray.direction * ray_length, Color.red);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, ray_length)) 
        {
            if (hit.collider.gameObject.tag == "Umbrella") 
            {
                Vector3 BounceDir = Vector3.Reflect(ray.direction, hit.normal);
                BounceDir = BounceDir.normalized;
                BounceDir = new Vector3(BounceDir.x, BounceDir.y, 0);
                ApplyForce(transform, BounceDir);
                hasBounced = true;
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
                r.AddForce(bounceDirection * force, ForceMode.VelocityChange);
            }
            ApplyForce(t, bounceDirection);
        }
    }
}
