using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable_OBject : MonoBehaviour
{
    public Camera_Shake cam;
    
    public void Hit(GameObject gameObject)
    {
        cam.startShake = true;
        cam.intensity = 0.4f;
    }
}
