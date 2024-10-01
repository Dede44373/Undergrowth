using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Health hp;
    public bool idleActive = true;
    public Player_Attacks playerAttack;
    public Rigidbody2D PlayerRigidBody;
    public float JumpStrength;
    [SerializeField] private LayerMask groundLayer;
    public float WalkSpeed;
    public PhysicsMaterial2D SlideMat;
    [SerializeField] private float gravityChange;
    public Camera Camera;
    private BoxCollider2D Collider;
    float horizontal;

    float vertical;
    bool InJump = false;
    int Landing = 2;
    private Animator anim;
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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded() && 
            playerAttack.usingSword == false)
        {
            jump();
        }

        if (PlayerRigidBody.velocity.y < 0)
        {
            PlayerRigidBody.gravityScale = gravityChange;
        } else
        {
            if (PlayerRigidBody.gravityScale != 1.5f)
            {
                PlayerRigidBody.gravityScale = 1.5f;
            }
        }

    }

    private void FixedUpdate()
    {
        //print(PlayerRigidBody.velocity.y);
        float horizontalInput = 0f;
        // Flipping character Left & right when moving + setting horizontalInput for convinience + WALKING SPEEEED
        if (hp.dead == false)
        {
            if (playerAttack.usingSword == false)
            {

                horizontalInput = Input.GetAxis("Horizontal");
                PlayerRigidBody.velocity = new Vector2(horizontalInput * WalkSpeed, PlayerRigidBody.velocity.y);
                if (horizontalInput > 0.01f)
                {
                    transform.localScale = new Vector3(0.4425f, 0.4425f, 0.4425f);
                    idleActive = false;

                }
                else if (horizontalInput < -0.01f)
                {
                    transform.localScale = new Vector3(-0.4425f, 0.4425f, 0.4425f);
                    idleActive = false;

                }
            }
            else
            {
                idleActive = true;
                PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, PlayerRigidBody.velocity.y);
            }


            //set animator parameters
            anim.SetBool("MC_Walk", horizontalInput != 0);
            anim.SetBool("grounded", IsGrounded());
        }
    }
    // What happens when you activate the "jump" function
    private void jump()
    {
        PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, JumpStrength);
        InJump = true;
        anim.SetTrigger("Jump");
        Collider.sharedMaterial = SlideMat;
        anim.SetTrigger("InAir");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycasthit.collider != null;

    }
}
