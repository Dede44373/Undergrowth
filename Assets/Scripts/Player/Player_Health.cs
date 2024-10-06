using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Player_Movement playM;
    [SerializeField] public float startingHealth;
    public float increaseHealth4;
    public float combined;
    public float currentHealth { get; private set; }
    private Animator anim;
    public bool dead;
    public bool hurt;

    [Header("iFrames")]
    [SerializeField] private float invulDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        increaseHealth4 = 0;
    }
    public void playerTakeDamage(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth + increaseHealth4);    

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            hurt= true;
            StartCoroutine(Invulnerability());
            //player is hurt
            
        }
        else 
        {
            //player is dead :)
            anim.SetTrigger("Die");
            dead = true;
            playM.PlayerRigidBody.velocity= Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            playerTakeDamage(1);


        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth + increaseHealth4);
        Debug.Log("Health aquired");
    }

    public void IncreaseMaxHealth (float num)
    {
        increaseHealth4 = 1;
        
        currentHealth = Mathf.Clamp(currentHealth + num, 0, startingHealth + increaseHealth4);
        Debug.Log("Health increased");
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        //invulnerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0.8f, 0.8f, 0.9f);
            yield return new WaitForSeconds(invulDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(8, 9, false);
        hurt = false;
    }
    public void FixedUpdate()
    {
        combined = startingHealth + increaseHealth4; 
    }
}
