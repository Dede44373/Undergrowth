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
    private bool notAtBoss = true;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //camera zoom stuff
    [SerializeField] private Camera cam;
    [SerializeField] private float zoom = 8f;
    [SerializeField] private float zoomSpeed;
    private float smoothTime = 0.5f;


    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    public float lookAhead;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    private void Update()
    {
        //bossroom camera movement
        if (doorTouched.atBoss == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX,  -14.5f, transform.position.z), ref velocity, speed);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize,zoom, ref zoomSpeed, smoothTime);
            notAtBoss = false;
        }

        //Follow player 
        if (doorTouched.atBoss == false && notAtBoss== true)
        {
            transform.position = new Vector3(player.position.x + lookAhead, player.position.y+1, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
            
        }
    }

    
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
