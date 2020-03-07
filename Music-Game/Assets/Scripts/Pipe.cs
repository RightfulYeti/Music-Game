using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float CurveRadius;
    public float PipeRadius;

    public int CurveSegmentCount;
    public int PipeSegmentCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Tutorial shows wrong formulas for 3D sinusoid function in bold text
    private Vector3 GetPointOnTorus(float u, float v)
    {
        Vector3 TorusPoint;
        float R = (CurveRadius + PipeRadius * Mathf.Cos(v));
        TorusPoint.x = R * Mathf.Sin(u);
        TorusPoint.y = R * Mathf.Cos(u);
        TorusPoint.z = PipeRadius * Mathf.Sin(v);
        return TorusPoint;
    }

    private void OnDrawGizmos()
    {
        float VStep = (2f * Mathf.PI) / PipeSegmentCount;

        for (int v = 0; v < PipeSegmentCount; v++)
        {
            Vector3 point = GetPointOnTorus(0f, v * VStep);
            Gizmos.DrawSphere(point, 0.1f);
        }
    }
}
