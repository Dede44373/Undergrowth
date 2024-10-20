using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int dmg;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //references
    private Animator anim;
    private Player_Health playerHealth;
    private Enemy_Patrol enemyPatrol;

    private void Awake()
    {
        anim=GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Enemy_Patrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Melee Attack");
            }

        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

    }   
    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            
            0,Vector2.left, 0, playerLayer);

        if(hit.collider != null ) 
            playerHealth = hit.transform.GetComponent<Player_Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
          new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    { 
        if (PlayerInSight())
        {   
            //if player still in range then will damage player
            playerHealth.playerTakeDamage(dmg);

        }
    }

}
