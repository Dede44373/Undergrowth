using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public Camera_Controller cont;
    public bool startShake=false;
    public AnimationCurve animationCurve;
    public float duration = 1f;
    public float intensity;
    void Update()
    {
        if (startShake == true)
        {
            startShake = false;
            StartCoroutine(Shaking());

        }
    }

    IEnumerator Shaking()
    {
        print("e");
        Vector3 startPosition = new Vector3(0, 0, 0);
        float elapsedTime = 0f;
        

        while (elapsedTime < duration)
        {
            //startPosition = new(player.localPosition.x, player.localPosition.y, player.localPosition.z - 5);
            elapsedTime += Time.deltaTime;
            float strength = animationCurve.Evaluate(elapsedTime/duration) * intensity;
            transform.position = startPosition + Random.insideUnitSphere * strength;
            //print(transform.parent.transform.position);
            yield return null;
        }

        transform.position = startPosition;
    }
}
