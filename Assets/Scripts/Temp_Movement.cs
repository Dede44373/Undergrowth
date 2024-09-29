using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Movement : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    public float JumpStrength;

    public float WalkSpeed;
    public PhysicsMaterial2D SlideMat;

    public Camera Camera;
    private BoxCollider2D Collider;
    float horizontal;

    float vertical;
    bool InJump = false;
    int Landing = 2;
    private Animator anim;
    private bool grounded;
    void Start()
    {
        // these scripts gets you references    
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump();
        }

    }

    private void FixedUpdate()
    {
        print(PlayerRigidBody.velocity.y);

        // Flipping character Left & right when moving + setting horizontalInput for convinience + WALKING SPEEEED
        float horizontalInput = Input.GetAxis("Horizontal");
        PlayerRigidBody.velocity = new Vector2(horizontalInput * WalkSpeed, PlayerRigidBody.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.4425f, 0.4425f, 0.4425f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.4425f, 0.4425f, 0.4425f);


        //set animator parameters
        anim.SetBool("MC_Walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    private void jump()
    {

        PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, JumpStrength);
        InJump = true;
        grounded = false;
        anim.SetTrigger("Jump");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
