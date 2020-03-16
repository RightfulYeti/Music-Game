using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool Done = false;
    public GameObject[] Men;
    public GameObject RB;
    public GameObject PlayerRef;
    private GameObject SpawnedDude;
    public GameObject RightWall;
    public GameObject LeftWall;
    private float MaxSpawnX;
    private float MaxSpawnY;
    private float SpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        //MaxSpawnX = Camera.main.ScreenToWorldPoint(new Vector3(RightWall.transform.position.x, 0, 0)).x;
        MaxSpawnX = RightWall.transform.position.x;
        MaxSpawnY = PlayerRef.transform.position.y + 15;
        print(MaxSpawnX);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnTimer += Time.deltaTime;

        //if (SpawnTimer >= 2.0f && !Done)
        //{
        //    SpawnedDude = Instantiate(Men[Random.Range(0, Men.Length)]);
        //    SpawnedDude.transform.position = new Vector3(Random.Range(LeftWall.transform.position.x, MaxSpawnX), MaxSpawnY, 0);
        //    //RB = Men[0].GetComponent<Rigidbody>();
        //    SpawnTimer = 0;
        //}

        if (Input.GetKeyDown(KeyCode.T) && !Done)
        {
            SpawnedDude = Instantiate(Men[Random.Range(0, Men.Length)]);
            SpawnedDude.transform.position = new Vector3(0, 15, 0);
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
                if (RB.transform.position.x < PlayerRef.transform.position.x)
                {
                    r.AddExplosionForce(30, transform.position + transform.right, 10f, 2f);
                }
                else if (RB.transform.position.x > PlayerRef.transform.position.x)
                    r.AddExplosionForce(30, transform.position + transform.right*-1, 10f, 2f);
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