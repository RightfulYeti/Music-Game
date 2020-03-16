using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    private float Timer;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        //MaxSpawnX = Camera.main.ScreenToWorldPoint(new Vector3(RightWall.transform.position.x, 0, 0)).x;
        MaxSpawnX = RightWall.transform.position.x;
        MaxSpawnY = PlayerRef.transform.position.y + 5;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = (int)Time.time;
        TimerText.text = Timer.ToString();
        SpawnTimer += Time.deltaTime;

        if (SpawnTimer >= 0.5f && !Done)
        {
            SpawnedDude = Instantiate(Men[Random.Range(0, Men.Length)]);
            SpawnedDude.transform.position = new Vector3(Random.Range(LeftWall.transform.position.x, MaxSpawnX), MaxSpawnY, 0);
            SpawnedDude.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            //RB = Men[0].GetComponent<Rigidbody>();
            SpawnTimer = 0;
        }

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
    }
}