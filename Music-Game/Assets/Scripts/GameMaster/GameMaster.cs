using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    bool Done = false;
    public GameObject[] Men;
    public Rigidbody RB;

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
            RB = Men[0].GetComponent<Rigidbody>();
            Done = true;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Done = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RB.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(15000, 10000, 0));
            print("Force!");
        }

    }

    void FixedUpdate()
    {  
    }
}
