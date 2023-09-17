using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public static int yourTurn;
    public static int isOpponentTurn;
    public TextMeshProUGUI turnText;

    public static int maxMentalEnergy;
    public static int currentMentalEnergy;
    public TextMeshProUGUI mentalEnergyText;

    public static bool startPlayerTurn;
    public static bool startEnemyTurn;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isOpponentTurn = 0;

        maxMentalEnergy = 1;
        currentMentalEnergy = 1;

        startPlayerTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn)
        {
            turnText.text = "Your Turn";

        }
        else
        {
            turnText.text = "Opponent Turn";
        }

        mentalEnergyText.text = currentMentalEnergy + "/" + maxMentalEnergy;
    }

    public void EndYourTurn()
    {
        if(isYourTurn)
        {
            isYourTurn = false;
            isOpponentTurn += 1;
            startPlayerTurn = false;
            startEnemyTurn = true;
        }
    }

    public static void EndOpponentTurn() 
    {
        if(!isYourTurn)
        {
            isYourTurn = true;
            yourTurn += 1;
            maxMentalEnergy += 1;
            currentMentalEnergy = maxMentalEnergy;

            startEnemyTurn = false;
            startPlayerTurn = true;
        }
    }
}
