using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Boss door shennanigans")]
    public Door door;
    [SerializeField] float speed;
    private Vector3 velocity = Vector3.zero;

    [Header ("Parallax things")] 
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length) 
        { 
            startPos -= length;   
        }

        if (door.atBoss == true)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(1.5f, 1.5f, transform.localScale.z), ref velocity, speed);
           
        }
        if (door.atBoss == false)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.9344f, 0.9344f, transform.localScale.z), ref velocity, speed);
        }
    }
    

}
