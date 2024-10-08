using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public Camera_Controller cont;
    [SerializeField] private Transform player;
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
        Vector3 startPosition = new(player.localPosition.x + cont.lookAhead, player.localPosition.y + 1, player.localPosition.z - 5);
        float elapsedTime = 0f;
        

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = animationCurve.Evaluate(elapsedTime/duration) * intensity;
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
