using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Transform NewMan;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T) && !done)
        {
            Instantiate(NewMan);
            done = true;
        }
        if (Input.GetKey(KeyCode.Y))
        {
            done = false;
            Destroy(NewMan);
        }
    }
}
