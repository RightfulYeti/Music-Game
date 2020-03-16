using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public Transform PivotPoint;
    public float ArmLength;

    public float rotation_angle = 0;

    void Start()
    {
        PivotPoint = transform.parent.transform;
    }

    void Update()
    {
        Vector3 PivotPointToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PivotPoint.position;
        PivotPointToMouseDir.z = 0;

        rotation_angle += Input.mouseScrollDelta.y * 2;

        transform.position = PivotPoint.position + (ArmLength * PivotPointToMouseDir.normalized);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, PivotPoint.position.y, Mathf.Infinity), transform.position.z);

        transform.Rotate(new Vector3(0, 0, 1), rotation_angle);
        rotation_angle = 0;
    }
}
