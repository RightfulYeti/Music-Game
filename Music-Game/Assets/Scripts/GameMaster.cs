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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RB.GetComponent<Animator>().enabled = false;
           // RB.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(1500, 1000, 1000));
            print("Force!");
        }

    }

    void FixedUpdate()
    {
        if (done)
        {
            RB.MovePosition(RB.position + new Vector3(1, 1, 0) * Time.fixedDeltaTime);
        }
           
    }
}
