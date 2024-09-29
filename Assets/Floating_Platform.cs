using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating_Platform : MonoBehaviour
{
    [SerializeField] Golden_Leaf gol;
    [SerializeField] private BoxCollider2D box;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    void Update()
    {
        if ( gol.touched== true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
