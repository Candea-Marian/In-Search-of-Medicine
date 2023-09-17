using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplaySymptomCard : MonoBehaviour
{
    [SerializeField]
    private List<SymptomCard> displaySymptomCard = new List<SymptomCard>();
    public int displayId;

    public int id;
    public string cardName;
    public int mentalCost;
    public int attackDamage;
    public int health;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;
    public bool cardBack;
    public static bool staticCardBack;

    public GameObject EnemyHand;
    public int numberOfCardsInDeck;

    void Start()
    {
        numberOfCardsInDeck = SymptomsDeck.deckSize;

        displaySymptomCard[0] = SymptomCardDatabase.symptomCardList[displayId];
        
    }

    // Update is called once per frame
    void Update()
    {

        id = displaySymptomCard[0].id;
        cardName = displaySymptomCard[0].cardName;
        mentalCost = displaySymptomCard[0].mentalCost;
        attackDamage = displaySymptomCard[0].attackDamage;
        health = displaySymptomCard[0].health;


        nameText.text = "" + cardName;
        costText.text = "" + mentalCost;
        damageText.text = "" + attackDamage;
        healthText.text = "" + health;

        EnemyHand = GameObject.Find("EnemyHand");

        if(this.transform.parent == EnemyHand.transform.parent)
        {
            cardBack = false;
        }

        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            displaySymptomCard[0] = SymptomsDeck.staticDeck[numberOfCardsInDeck - 1];
            int damage = displaySymptomCard[0].attackDamage;
            ClientHP.staticHealth -= damage;
            numberOfCardsInDeck -= 1;
            SymptomsDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

    }
}
