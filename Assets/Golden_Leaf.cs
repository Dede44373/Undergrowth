using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golden_Leaf : MonoBehaviour
{
    public bool touched = false;
   [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "Player")
            collision.GetComponent<Player_Health>().IncreaseMaxHealth(healthValue);
            touched = true;
            gameObject.SetActive(false);
    }
}
