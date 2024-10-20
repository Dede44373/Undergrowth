using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Player_Movement playM;
    [SerializeField] public float startingHealth;
    public float increaseHealth = 0;
    public float combined;
    public float currentHealth { get; private set; }
    private Animator anim;
    public bool dead;
    public bool hurt;

    [Header("iFrames")]
    [SerializeField] private float invulDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public Camera_Shake cam;
    public Golden_Leaf leaf;
    public Golden_Leaf leaf2;

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        increaseHealth = 0;
    }
    public void playerTakeDamage(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth + increaseHealth);    

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            hurt= true;
            StartCoroutine(Invulnerability());
            cam.startShake = true;
            cam.intensity = 0.4f;
            //player is hurt
            
        }
        else 
        {
            //player is dead :)
            anim.SetTrigger("Die");
            dead = true;
            playM.PlayerRigidBody.velocity= Vector3.zero;
            cam.startShake = true;
            cam.intensity = 0.8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            playerTakeDamage(1);

        }
    }
    public void IncreaseMaxHealth (float num)
    {
        currentHealth = Mathf.Clamp(leaf.healthValue, 0, startingHealth + increaseHealth);
        Debug.Log("Health increased");
        AddHealth(5);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth + increaseHealth);
        Debug.Log("Health aquired");
    }

    public void MaxingHealth(float _value)
    {
        currentHealth = leaf.healthValue;
        Debug.Log("Health aquired");
    }
    public void MaxingHealth2(float _value)
    {
        currentHealth = leaf2.healthValue;
        Debug.Log("Health aquired");
    }
    public void Respawn()
    { 
        dead = false;
        AddHealth(startingHealth+increaseHealth);
        anim.ResetTrigger("Die");
        anim.ResetTrigger("Hurt");
        anim.SetTrigger("Alive");
        StartCoroutine(Invulnerability());
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
        combined = startingHealth + increaseHealth; 
    }
}
