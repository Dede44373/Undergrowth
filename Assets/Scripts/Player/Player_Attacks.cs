using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    [Header ("References")]
    public Player_Movement movement;
    public Interactable_Object Interactable_Object;
    public Animator anim;
    public Breakable_Object Object;

    [Header ("Attacking stats")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    [Header("Misc Variables")]
    public bool usingSword = false;
    public bool hurtObject;
    public int playerPower;

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
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Return) && usingSword == false && Interactable_Object.setSwordActive == true) // if the enter key is pressed, and the usingSword boolean value is set to false then we can run the following code below
            {
                usingSword = true;
                anim.SetTrigger("Attack1");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (hurtObject == true) // checks if player is attacking the object
        {
            hurtObject = false;
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
        yield return new WaitForSeconds(0.3f); // adjust as needed, so far just waiting a very small amount

        movement.PlayerRigidBody.drag = 0; // whatever ur number is
        usingSword = false;
        StopCoroutine(SpeedUp());
    }



    void attack()
    {
        //Plays attack animation

        // Detect Enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
  

        //Damage them
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
          
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
