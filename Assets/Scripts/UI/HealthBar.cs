using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player_Health playerHealth;
    [SerializeField] private Image totalhealthbarBar; 
    [SerializeField] private Image currenthealthBar;

    // Start is called before the first frame update
    private void Start()
    {
        totalhealthbarBar.fillAmount = playerHealth.currentHealth /5;
    }

    // Update is called once per frame
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth/5;
    }
}
