using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float CurveRadius;
    public float PipeRadius;

    public int CurveSegmentCount;
    public int PipeSegmentCount;

    private Mesh Mesh;
    private Vector3[] Vertices;
    private int[] Triangles;

    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = Mesh = new Mesh();
        Mesh.name = "Pipe";
        SetVertices();
        SetTriangles();
        Mesh.RecalculateNormals();
    }

    private void SetVertices()
    {
        Vertices = new Vector3[PipeSegmentCount * CurveSegmentCount * 4];
        float uStep = (2f * Mathf.PI) / CurveSegmentCount;
        CreateFirstQuadRing(uStep);
        int iDelta = PipeSegmentCount * 4;
        for (int u = 2, i = iDelta; u <= CurveSegmentCount; u++, i += iDelta)
        {
            CreateQuadRing(u * uStep, i);
        }
        Mesh.vertices = Vertices;
    }

    private void CreateFirstQuadRing(float u)
    {
        float vStep = (2f * Mathf.PI) / PipeSegmentCount;

        Vector3 VertexA = GetPointOnTorus(0f, 0f);
        Vector3 VertexB = GetPointOnTorus(u, 0f);
        for (int v = 1, i = 0; v <= PipeSegmentCount; v++, i += 4)
        {
            Vertices[i] = VertexA;
            Vertices[i + 1] = VertexA = GetPointOnTorus(0f, v * vStep);
            Vertices[i + 2] = VertexB;
            Vertices[i + 3] = VertexB = GetPointOnTorus(u, v * vStep);
        }
    }

    private void CreateQuadRing(float u, int i)
    {
        float vStep = (2f * Mathf.PI) / PipeSegmentCount;
        int RingOffset = PipeSegmentCount * 4;

        Vector3 vertex = GetPointOnTorus(u, 0f);
        for (int v = 1; v <= PipeSegmentCount; v++, i += 4)
        {
            Vertices[i] = Vertices[i - RingOffset + 2];
            Vertices[i + 1] = Vertices[i - RingOffset + 3];
            Vertices[i + 2] = vertex;
            Vertices[i + 3] = vertex = GetPointOnTorus(u, v * vStep);
        }
    }

    private void SetTriangles()
    {
        Triangles = new int[PipeSegmentCount * CurveSegmentCount * 6];
        for (int t = 0, i = 0; t < Triangles.Length; t += 6, i += 4)
        {
            Triangles[t] = i;
            Triangles[t + 1] = Triangles[t + 4] = i + 1;
            Triangles[t + 2] = Triangles[t + 3] = i + 2;
            Triangles[t + 5] = i + 3;
        }
        Mesh.triangles = Triangles;
    }

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
        float uStep = (2f * Mathf.PI) / CurveSegmentCount;
        float vStep = (2f * Mathf.PI) / PipeSegmentCount;

        for (int u = 0; u < CurveSegmentCount; u++)
        {
            for (int v = 0; v < PipeSegmentCount; v++)
            {
                Vector3 point = GetPointOnTorus(u * uStep, v * vStep);
                Gizmos.color = new Color(
                    1f,
                    (float)v / PipeSegmentCount,
                    (float)u / CurveSegmentCount);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }

}
