using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Controller : MonoBehaviour
{
    //Boss rooom camera movement
    [SerializeField] private float speed;
    public Door doorTouched;
    public bool notAtBoss = true;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //camera zoom stuff
    [SerializeField] private Camera cam;
    [SerializeField] private float zoom = 8f;
    [SerializeField] private float zoomSpeed;
    private float smoothTime = 0.5f;


    // Follow player
    public Player_Health health;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    public float lookAhead;

    public void Start()
    {
       
        transform.localScale = new Vector3(1, 1, 1);
    }
 
    public void Update()  
    {
        //Follow player
        if (notAtBoss == true)
        {
            transform.position = new Vector3(player.position.x + lookAhead, player.position.y + 1, transform.position.z);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 5, ref zoomSpeed, smoothTime);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        }

            if (health.dead == true)
            {
                notAtBoss = true;
                doorTouched.atBoss = false;
            }

        if (doorTouched.atBoss == true)
        {
            notAtBoss = false;
            Arena();
        }
    }
    public void Arena()
    {
        if (doorTouched.atBoss == true && notAtBoss == false)
        {   
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomSpeed, smoothTime);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, 1f, transform.position.z), ref velocity, speed);
            notAtBoss = false;
        }
     

    }
    
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
