using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Idle : MonoBehaviour
{
    public Player_Attacks atk;
    public Player_Movement mov;
    public GameObject SideSword;
    public Interactable_Object obj;
    // Start is called before the first frame update
    void Start()
    {
        SideSword.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {  if (obj.idleAct == true)
            {
                    SideSword.GetComponent<Renderer>().enabled = true;

                if (atk.usingSword == true)
                {
                SideSword.GetComponent<Renderer>().enabled = false;

                }

                else 
                {
                SideSword.GetComponent<Renderer>().enabled = true;
            
                if (mov.idleActive == true)
                {
                    transform.localScale = new Vector2(1f, 1.2f);
                }
                if (mov.idleActive == false)
                {
                    transform.localScale = new Vector2(1.2f, 1.2f);
                }


                }

            }
        
        
    }
}
