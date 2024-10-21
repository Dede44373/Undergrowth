using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    public bool dead;

    [Header("iFrames")]
    [SerializeField] private float invulDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public Camera_Shake cam;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth);

        if (currentHealth > 0)
        {
  
        
            StartCoroutine(Invulnerability());
            //enemy is hurt
            cam.startShake =true;
            cam.intensity = 0.3f;
      
        }
        else
        {
            //enemy is dead :)
            anim.SetTrigger("Die");
            cam.startShake = true;
            cam.intensity = 0.6f;
            GetComponent<BoxCollider2D>().enabled = false;
            dead = true;
            //Disabling enemy patrol

            if (GetComponentInParent<Enemy_Patrol>() != null ) 
            GetComponentInParent<Enemy_Patrol>().enabled = false;

            if (GetComponentInParent<EnemyMelee>() != null)
                GetComponent<EnemyMelee>().enabled = false;
        }
    }
    private void die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            TakeDamage(1);


        }
    }
    private IEnumerator Invulnerability()
    {
        
        //invulnerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
             print("fjnwkfnjk");
            spriteRend.color = Color.red;
            yield return new WaitForSeconds(invulDuration / (numberOfFlashes * 2));
            spriteRend.color =  Color.white;
            yield return new WaitForSeconds(invulDuration / (numberOfFlashes * 2));
        }
        StopAllCoroutines();
    }
}
