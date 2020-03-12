using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool done = false;
    public GameObject[] Men;
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !done)
        {
            Instantiate(Men[Random.Range(0, Men.Length)]);
            RB = Men[0].GetComponent<Rigidbody>();
            done = true;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            done = false;
        }
        RB.GetComponentInChildren<Rigidbody>().velocity = new Vector3(10, 10, 0) * Time.deltaTime;
        if (done)
        {
            for (int i = 0; i < RB.GetComponentsInChildren<Rigidbody>().Length; i++)
            {
                //RB.GetComponentsInChildren<Rigidbody>()[i].AddForce(new Vector3(1500, 1000, 1000));
                RB.GetComponentsInChildren<Rigidbody>()[i].velocity = new Vector3(10, 10, 0) * Time.deltaTime;
            }
        }


        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    for (int i = 0; i < RB.GetComponentsInChildren<Rigidbody>().Length; i++)
        //    {
        //        RB.GetComponentsInChildren<Rigidbody>()[i].AddForce(new Vector3(1500, 1000, 1000));
        //    }
        //    print("Force!");
        //}

    }

    void FixedUpdate()
    {
        //if (done)
        //{
        //    RB.MovePosition(RB.position + new Vector3(10, 10, 0) * Time.fixedDeltaTime);
        //}
           
    }
}
