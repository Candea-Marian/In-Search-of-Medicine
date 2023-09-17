using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomsDeck : MonoBehaviour
{
    
    public int x;
    public static int deckSize;
    public List<SymptomCard> deck = new List<SymptomCard>();
    public List<SymptomCard> container = new List<SymptomCard>();
    public static List<SymptomCard> staticDeck = new List<SymptomCard>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject[] SymptomClones;
    public GameObject EnemyHand;

    public GameObject CardToEnemyHand;

    public Disease disease;
    // Start is called before the first frame update
    void Start()
    {
        deckSize = 4;
        for(int i = 0; i < deckSize; i++)
        {
            deck[i] = SymptomCardDatabase.symptomCardList[i];
        }

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

        if(TurnSystem.startEnemyTurn)
        {
            if(deckSize > 0)
            {
                StartCoroutine(Draw(1));
                TurnSystem.startEnemyTurn = false;
                TurnSystem.EndOpponentTurn();
            }
            
        }
    }

    IEnumerator StartGame()
    {
        
        yield return new WaitForSeconds(3);
        //audioSource.PlayOneShot(draw, 1f);
        Instantiate(CardToEnemyHand, transform.position, transform.rotation);
        
    }


    IEnumerator Draw(int numberOfCards)
    {
        for(int i = 0; i < numberOfCards; i++)
        {
            yield return new WaitForSeconds(3);
            Instantiate(CardToEnemyHand, transform.position, transform.rotation);
            int damage = CardToEnemyHand.GetComponent<DisplaySymptomCard>().attackDamage;
            // ClientHP.staticHealth -= damage;
            // Debug.Log("Attack damage: " + damage);
            // Debug.Log("name: " + CardToEnemyHand.GetComponent<DisplaySymptomCard>().cardName);
        }
    }

    public void Shuffle()
    {
        // Implement your shuffle algorithm here
        // For example, you can use the Fisher-Yates shuffle algorithm
        for (int i = deckSize - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            SymptomCard temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}
