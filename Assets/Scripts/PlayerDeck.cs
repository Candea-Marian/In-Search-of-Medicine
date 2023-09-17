using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    
    public int x;
    public static int deckSize;
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject[] Clones;
    public GameObject Hand;

    public GameObject CardToHand;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 6;

        deck[0] = CardDatabase.cardList[0];
        deck[1] = CardDatabase.cardList[1];
        deck[2] = CardDatabase.cardList[1];
        deck[3] = CardDatabase.cardList[2];
        deck[4] = CardDatabase.cardList[3];
        deck[5] = CardDatabase.cardList[4];

        // for(int i = 0; i < deckSize; i++)
        // {
        //     x = Random.Range(0, 5);
        //     deck[i] = CardDatabase.cardList[x];
        // }

        Shuffle();

        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if(deckSize < 4)
        {
            cardInDeck1.SetActive(false);
        }
        if(deckSize < 3)
        {
            cardInDeck2.SetActive(false);
        }
        if(deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        if(deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }

        if(TurnSystem.startPlayerTurn)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startPlayerTurn = false;
        }
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i <= 3; i++) 
        {
            yield return new WaitForSeconds(1);
            //audioSource.PlayOneShot(draw, 1f);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator Draw(int numberOfCards)
    {
        for(int i = 0; i < numberOfCards; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        // Implement your shuffle algorithm here
        // For example, you can use the Fisher-Yates shuffle algorithm
        for (int i = deckSize - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Card temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}
