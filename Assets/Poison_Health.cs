using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float invulDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public Camera_Shake cam;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
 
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth);

        if (currentHealth > 0)
        {

            die();
            //enemy is hurt

        }
        else
        {
            //enemy is dead :)
            die();
        }
    }
    private void die()
    {
        cam.startShake = true;
        cam.intensity = 0.2f;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            TakeDamage(1);


        }
    }

}
