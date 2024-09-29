using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    public Player_Movement movement;
    public Interactable_Object Interactable_Object;
    public bool usingSword = false;
    public Breakable_Object Object;
    public bool hurtObject;
    public int playerPower;
    private Animator Animator;
    [SerializeField] private float speed;
    [SerializeField] private float shiftDistance;
    [SerializeField] private float drag;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    // Checks if player is taking damage and destroys sprite if it does enough
   

    
    
    // Update is called once per frame
    void Update()
    {
        if (hurtObject == true) // checks if player is attacking the object
        {
            //attackObject();
            hurtObject = false; 

        }

        if (Input.GetKeyDown(KeyCode.Return) && usingSword == false && Interactable_Object.setSwordActive == true) // if the enter key is pressed, and the usingSword boolean value is set to false then we can run the following code below
        {
            
            usingSword = true; // set usingSword to true so that we cant run this twice, as we would need this to be false in order to run this again
            Animator.SetBool("SwordSwing", true); // set the boolean SwordSwing to true on the animator so we can play the animation
            if (movement.transform.localScale.x > 0)
            {

                StartCoroutine(SpeedUp());
                movement.PlayerRigidBody.AddForce(new Vector2(shiftDistance, 0));

            }
            else
            {
                StartCoroutine(SpeedUp());
                movement.PlayerRigidBody.AddForce(new Vector2(-shiftDistance, 0));
            }
        }
    }

    private IEnumerator SpeedUp()
    {
        movement.PlayerRigidBody.drag = drag; // change this number
        yield return new WaitForSeconds(0.5f); // adjust as needed, so far just waiting a very small amount

        movement.PlayerRigidBody.drag = 0; // whatever ur number is
        StopCoroutine(SpeedUp());
    }



        // Animation plays and reaches "SwordEnable" marker in animation timeline and sets IEnumerator active
        IEnumerator SwordEnable() // Coroutine here, its like a function but it allows for time waiting and it will not interrupt the code. What i mean by this is that no amount of waiting will freeze the code
    {
        Animator.SetBool("SwordSwing", false); // Set the animator bool SwordSwing back to false so we can return to the idle thingy so we can do this all again woohooo
        yield return new WaitForSeconds(0.2f); // Wait 0.2 seconds, this is one of the thinsg Coroutines (or IEnumerators) provide that voids do not (unfortunately)

        usingSword = false; // set the usingSword boolean back to false so that first if statement with the enter key can now be met again
    }

    void sword()
    {
        if (Input.GetKeyDown(KeyCode.P) == true)
        {
            /*
            swordSwing = true;
            gameObject.SetActive(true);
            yield return new WaitForSeconds (1);
            swordSwing = false;
            gameObject.SetActive(false);
            */

            Animator.SetBool("SwordSwing", true);
            //Animator.SetBool("SwordSwing", false);
        }

    }
    /*void attackObject()
    { 
        Object.objectTakeDamage(playerPower);
    }
    */

}
