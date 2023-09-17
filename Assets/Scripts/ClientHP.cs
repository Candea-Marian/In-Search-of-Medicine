using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientHP : MonoBehaviour
{

    public static float maxHealth;
    public static float staticHealth;
    public float health;
    public Image healthImg;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        staticHealth = 10;

        
    }

    // Update is called once per frame
    void Update()
    {
        health = staticHealth;
        healthImg.fillAmount = health / maxHealth;

        if(health >= maxHealth)
        {
            health = maxHealth;
        }

        healthText.text = "" + health;
    }
}
