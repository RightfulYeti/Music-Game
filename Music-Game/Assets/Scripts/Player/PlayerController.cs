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
    public Camera Cam;
    Collider[] GroundCollisions;
    Collider[] DudeCollisions;
    Rigidbody RB;
    public LayerMask GroundLayer;
    public LayerMask DudeLayer;
    public Transform GroundCheck;
    private float Timer;
    Vector3 minScreenBounds;
    Vector3 maxScreenBounds;
    public Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
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
            Flip();
        }
        else if (Move < 0 && FacingRight)
        {
            Flip();
        }

        GroundCollisions = Physics.OverlapSphere(GroundCheck.position, GroundCheckRadius, GroundLayer);
        DudeCollisions = Physics.OverlapSphere(GroundCheck.position, GroundCheckRadius, DudeLayer);
        if (GroundCollisions.Length > 0 || DudeCollisions.Length > 0)
        {
            OnGround = true;
            PlayerAnimator.SetBool("Jumping", false);
        }
        else
        {
            OnGround = false;
            PlayerAnimator.SetBool("Jumping", true);
        }

        if (OnGround && Input.GetAxis("Jump") > 0)
        {
            OnGround = false;
            RB.AddForce(new Vector3(0, JumpPower, 0));
            PlayerAnimator.SetBool("Jumping", true);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Dude")
        {
            OnGround = true;
        }
    }
}
