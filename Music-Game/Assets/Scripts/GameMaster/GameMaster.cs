using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool Done = false;
    public GameObject[] Men;
    public GameObject RB;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !Done)
        {
            Instantiate(Men[Random.Range(0, Men.Length)]);
            //RB = Men[0].GetComponent<Rigidbody>();
            Done = true;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Done = false;
        }

        //CopyTransformsRecurse(transform, RB.transform);
        ApplyForce(RB.transform);
    }

    private void ApplyForce(Transform target)
    {
        foreach (Transform t in target)
        {
            Rigidbody r = t.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(30, transform.position + transform.right, 10f, 2f); //r.AddExplosionForce(30, transform.position + transform.forward, 10f, 2f);
            }
                
            ApplyForce(t);
        }
    }

    //public static void CopyTransformsRecurse(Transform src, Transform dst)
    //{
    //    dst.position = src.position;
    //    dst.rotation = src.rotation;
    //    foreach (Transform child in dst)
    //    {
    //        Transform curSrc = src.Find(child.name);
    //        if (curSrc)
    //            CopyTransformsRecurse(curSrc, child);
    //    }
    //}
}