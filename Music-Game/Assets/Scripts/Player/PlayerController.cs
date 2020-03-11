using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.0f;
    private float Move = 0.0f;
    private float GroundCheckRadius = 0.2f;
    public float JumpPower = 0.0f;
    bool FacingRight = true;
    public bool OnGround;

    Collider[] GroundCollisions;
    Rigidbody2D RB;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime; 
    }

    private void FixedUpdate()
    {
        Move = Input.GetAxis("Horizontal");
        RB.velocity = new Vector3(Move * Speed, RB.velocity.y, 0);

        if (Move > 0 && !FacingRight)
        {
            print("Flipped");
            Flip();
        }
        else if (Move < 0 && FacingRight)
        {
            print("Flipped");
            Flip();
        }

        GroundCollisions = Physics.OverlapSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);
        if (GroundCollisions.Length > 0)
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }

        if (OnGround && Input.GetAxis("Jump") > 0)
        {
            print("jump");
            OnGround = false;
            RB.AddForce(new Vector3(0, JumpPower, 0));
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scale = transform.localScale;
        Scale.z *= -1;
        transform.localScale = Scale;
    }

    public int GetDir()
    {
        if (FacingRight)
            return 1;
        else
            return 0;
    }
}
