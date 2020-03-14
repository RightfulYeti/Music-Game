using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public Camera cam;  //Drag the camera object here
    Vector3 mouse_pos;
    public Transform target; //Assign to the object you want to rotate
    Vector3 object_pos;
    float angle;

    Vector3 delta_umbrella_pos;
    Vector3 previous_umbrella_pos;
    Vector3 delta_mouse_pos;
    Vector3 previous_mouse_pos;
    Vector3 orbit_mouse_vector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;

        orbit_mouse_vector = Input.mousePosition;

        delta_mouse_pos = previous_mouse_pos - orbit_mouse_vector;
        delta_umbrella_pos = previous_umbrella_pos - transform.position;

        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

        if(delta_mouse_pos.x < 0) 
        {
            angle *= -1;
        }

        if (delta_mouse_pos.x != 0) {
            if (transform.position.y >= target.position.y) 
            {
                transform.position = RotatePointAroundPivot(transform.position, target.position, Quaternion.Euler(0, 0, angle * Time.deltaTime * 5));
            }
            else 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z); // change this to make the bounce back smother smaller smother
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        }
        //delta_mouse_pos = Vector3.zero;
        previous_mouse_pos = orbit_mouse_vector;
        previous_umbrella_pos = transform.position;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
        return angle * (point - pivot) + pivot;
    }
}
