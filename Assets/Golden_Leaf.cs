using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golden_Leaf : MonoBehaviour
{
    public bool touched = false;
    public float healthValue;
    public Player_Health health;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "Player")
            collision.GetComponent<Player_Health>().IncreaseMaxHealth(healthValue);
            collision.GetComponent<Player_Health>().AddHealth(healthValue);
            collision.GetComponent<Player_Health>().MaxingHealth(healthValue);
            health.increaseHealth++;
            touched = true;
            gameObject.SetActive(false);
    }
}
