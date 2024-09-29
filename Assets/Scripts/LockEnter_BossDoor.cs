using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnter_BossDoor : MonoBehaviour
{
    public Door door;
    private float speed=0.15f;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        transform.position = new Vector3(86.7981f, -10, transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        if (door.atBoss == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(86.7981f, -17, transform.position.z), ref velocity, speed);


        }
    }
}
