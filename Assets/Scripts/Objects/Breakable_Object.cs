using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Object : MonoBehaviour
{
    public int objectHealth;
    // Start is called before the first frame update
    public void objectTakeDamage(int damage) // int damage is the amount of damage we take
    {
        objectHealth -= damage; // subtract damage
        if (objectHealth <= 1) // if its below or equals to zero then run the code below
        {
            Destroy(gameObject); // destroy the wall lol
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Whenever a collider that has 'IsTrigger' set to true touches this, it will run whatever is below, Collider2D collision being the thing that touched it
    {
        if (collision.CompareTag("Sword"))
        {
            objectTakeDamage(1); // Calls the objectTakeDamage function, with the parameter 1 which in your case, how u set up the function being 1 damage
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
