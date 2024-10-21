using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave_Controller : MonoBehaviour
{
    public Door door;
    public Boss_Enemies enemies;
    public float bodyCount;
    public bool wave2 = false;
    public bool wave3 = false;
    void Start()
    {
        bodyCount = 0;
    }

   
    void Update()
    {
        if (door.atBoss == true)
        {
            
            if (bodyCount == 2)
            {
                wave2 = true;
            }

            if (bodyCount == 5)
            {
                SceneManager.LoadScene("Levels/Win Screen");
            }
        }
    }
}
