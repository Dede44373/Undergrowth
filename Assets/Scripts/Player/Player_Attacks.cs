using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    [Header("References")]
    public Player_Movement movement;
    public Interactable_Object Interactable_Object;
    public Animator anim;
    public Breakable_Object Object;
    public Player_Health HP;

    [Header("Attacking stats")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage;
    public LayerMask enemyLayers;
    public LayerMask wallLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    [Header("Misc Variables")]
    public bool usingSword = false;
    public bool hurtObject;
    public int playerPower;
    public bool inCombo;

    [Header("Shifting Distance")]
    [SerializeField] private float speed;
    [SerializeField] private float shiftDistance;
    [SerializeField] private float drag;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Checks if player is taking damage and destroys sprite if it does enough




    // Update is called once per frame
    public void CloseCombo()
    {
        anim.SetBool("InCombo", false);
        usingSword = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && movement.IsGrounded() && Interactable_Object.setSwordActive == true) // if the enter key is pressed, and the usingSword boolean value is set to false then we can run the following code below
        {
            if (usingSword == false)
            {
                usingSword = true;
                anim.SetTrigger("Attack1");
            } else
            {
                if (anim.GetBool("InCombo") == false)
                {
                    anim.SetBool("InCombo", true);
                }
            }

            nextAttackTime = Time.time + 1f / attackRate;

        }

        if (hurtObject == true) // checks if player is attacking the object
        {
            hurtObject = false;
        }

        if (HP.hurt == true)
        {
            usingSword = false;
        }
        //usingSword = true; // set usingSword to true so that we cant run this twice, as we would need this to be false in order to run this again
        // set the boolean SwordSwing to true on the animator so we can play the animation
        /* if (movement.transform.localScale.x > 0)
         {

             StartCoroutine(SpeedUp());
             movement.PlayerRigidBody.AddForce(new Vector2(shiftDistance, 0));

         }
         else
         {
             StartCoroutine(SpeedUp());
             movement.PlayerRigidBody.AddForce(new Vector2(-shiftDistance, 0));
         }
     }
 }*/
    }
    private IEnumerator SpeedUp()
    {
        movement.PlayerRigidBody.drag = drag; // change this number
        yield return new WaitForSeconds(0.4f); // adjust as needed, so far just waiting a very small amount

        movement.PlayerRigidBody.drag = 0; // whatever ur number is
        //usingSword = false;
        StopCoroutine(SpeedUp());
    }

    public void EnableSword()
    {
        print(inCombo);
        if (!anim.GetBool("InCombo"))
        {
            usingSword = false;
        }
    }


    void attack()
    {
        //Plays attack animation

        // Detect Enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        Collider2D[] hitBarricade = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wallLayers);


        foreach (Collider2D Enemy in hitBarricade)
        {
            if (Enemy.GetComponent<Breakable_Object>())
            {
                Debug.Log("wall Hit");
                Enemy.GetComponent<Breakable_Object>().TakeDamage(attackDamage);
            }
        }

        //Damage them
        foreach (Collider2D Enemy in hitEnemies)
        {
            if (Enemy.GetComponent<EnemyHealth>())
            {
                Enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                Debug.Log("Enemy Hit");
            }

            if (Enemy.GetComponent<Knockback>())
            {
                Enemy.GetComponent<Knockback>().PlayFeedback(gameObject);
            }
            if (Enemy.GetComponent<Moveable_OBject>())
            {
                Enemy.GetComponent<Moveable_OBject>().Hit(gameObject);
            }
        }
        if (movement.transform.localScale.x > 0)
        {

            StartCoroutine(SpeedUp());
            movement.PlayerRigidBody.AddForce(new Vector2(shiftDistance, 0));

        }
        else
        {
            StartCoroutine(SpeedUp());
            movement.PlayerRigidBody.AddForce(new Vector2(-shiftDistance, 0));

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
