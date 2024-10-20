using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerPos;
    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerPos.position + new Vector3(0, 0, -10);
    }
}
