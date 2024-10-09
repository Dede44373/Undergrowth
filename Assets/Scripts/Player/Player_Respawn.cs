using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    //[SerializeField] private AudioClip checkpointSound; //sound effect that will play when you activate checkpoint
    private Transform currentCheckpoint;
    private Player_Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Player_Health>();
    }

    public void Respawn()
    { 
        transform.position = currentCheckpoint.position; //Move player to checkpoint Location
        playerHealth.Respawn(); //Restrore player health and reset animation

        //Move Camera back to checkpoint

    }

    //active checkpoin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint we activated as the current one
            collision.GetComponent<Collider2D>().enabled = false; //deactive checkpoint
            collision.GetComponent<Animator>().SetTrigger("Appear"); //triigers appear
            //collision.GetComponent<Animator>().SetTrigger("Idle");
        }
    }

}
