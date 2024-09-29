using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{
    public int enemyHealth;
    // Start is called before the first frame update
    public void enemyTakeDamage(int damage) // int damage is the amount of damage we take
    {
        enemyHealth -= damage; // subtract damage
        if (enemyHealth <= 1) // if its below or equals to zero then run the code below
        {
            Destroy(gameObject); // destroy the wall lol
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Whenever a collider that has 'IsTrigger' set to true touches this, it will run whatever is below, Collider2D collision being the thing that touched it
    {
        if (collision.CompareTag("Sword"))
        {
            enemyTakeDamage(1); // Calls the objectTakeDamage function, with the parameter 1 which in your case, how u set up the function being 1 damage

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
