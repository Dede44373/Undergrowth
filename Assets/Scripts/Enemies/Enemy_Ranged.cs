using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float rangeX;
    [SerializeField] private float rangeY;
    [SerializeField] private int dmg;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] poison;

    [Header ("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Player_Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
                anim.SetTrigger("Attack");
            }

        }

        void RangedAttack()
        {
            cooldownTimer = 0;
            poison[FindPoison()].transform.position = firepoint.position;
            poison[FindPoison()].GetComponent<Enemy_Projectile>().ActivateProjectile();
            //shooting balls

        }
        int FindPoison()
        {
            for (int i = 0; i < poison.Length; i++)
            {
                if (poison[i].activeInHierarchy)
                    return i;

            }
                return 0;
        }   

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rangeX * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * rangeX, boxCollider.bounds.size.y * rangeY, boxCollider.bounds.size.z),

            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Player_Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * rangeX * transform.localScale.x * colliderDistance,
          new Vector3(boxCollider.bounds.size.x * rangeX, boxCollider.bounds.size.y * rangeY, boxCollider.bounds.size.z));
    }

}
