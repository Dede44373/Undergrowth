using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private Camera_Controller cam;
    public bool atBoss;

    public void Update()
    {
        if(cam.notAtBoss == true)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            atBoss = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                atBoss = true;
                cam.Arena();
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
            }
        }
    }
}
