using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : EnemyDamage //will damage the player
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    public GameObject RangedEnemy;
    public EnemyHealth enemyHealth;

    public void ActivateProjectile()
    {
        lifetime = 0;
        
        gameObject.SetActive(true);
        new Vector3(transform.localScale.x * RangedEnemy.transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(-movementSpeed * RangedEnemy.transform.localScale.x,0,0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
        if (enemyHealth.dead == true)
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")||collision.CompareTag("Sword"))
        {
            base.OnTriggerEnter2D(collision); //executes the logic from parent script first (in this case EnemyDamage)
            gameObject.SetActive(false);
        }
    }
}
