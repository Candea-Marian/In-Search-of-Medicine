using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    [SerializeField]
    private List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int mentalCost;
    public int attackDamage;
    public int health;
    public string cardDescription;
    public List<string> itCanHeal;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI descriptionText;
    public Image img;
    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;

        displayCard[0] = CardDatabase.cardList[displayId];
        
    }

    // Update is called once per frame
    void Update()
    {

        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        mentalCost = displayCard[0].mentalCost;
        attackDamage = displayCard[0].attackDamage;
        health = displayCard[0].health;
        cardDescription = displayCard[0].cardDescription;
        itCanHeal = displayCard[0].itCanHeal;

        nameText.text = "" + cardName;
        costText.text = "" + mentalCost;
        damageText.text = "" + attackDamage;
        healthText.text = "" + health;
        descriptionText.text = "" + cardDescription;
        img.sprite = displayCard[0].cardImage;

        Hand = GameObject.Find("Hand");

        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }

    }
}
