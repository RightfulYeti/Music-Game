using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public Transform PivotPoint;
    public float ArmLength;

    void Start()
    {
        PivotPoint = transform.parent.transform;
    }

    void Update()
    {
        Vector3 PivotPointToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PivotPoint.position;
        PivotPointToMouseDir.z = 0; 
        transform.position = PivotPoint.position + (ArmLength * PivotPointToMouseDir.normalized);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, PivotPoint.position.y, Mathf.Infinity), transform.position.z);

    }
}
