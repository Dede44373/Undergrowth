using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    public Door door;
    public EnemyHealth enemyHealth;
    public Wave_Controller control;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Update()
    {
        if (control.wave2 == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 1;

        }
        if (enemyHealth.dead == true)
        {
            control.bodyCount++;
            gameObject.SetActive(false);
        }
    }
}
