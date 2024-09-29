using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable_Object : MonoBehaviour
{
    public bool idleAct;
    public Player_Attacks attackActive;
    private bool triggerActive = false;
    public GameObject deadSword;
    public bool setSwordActive = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        setSwordActive = true;
        idleAct = true;
        gameObject.SetActive(false);
    }
}
// Update is called once per frame

