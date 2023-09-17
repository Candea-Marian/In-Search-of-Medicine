using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Card
{
    
    public int id;
    public string cardName;
    public int mentalCost;
    public int attackDamage;
    public int health;
    public string cardDescription;
    public Sprite cardImage;
    public List<string> itCanHeal;

    public Card()
    {

    }

    public Card(int identifier, string name, int cost, int damage, int healthPoints, List<string> symptoms, Sprite image)
    {
        id = identifier;
        cardName = name;
        mentalCost = cost;
        attackDamage = damage;
        health = healthPoints;
        cardDescription = "It can heal:";
        cardImage = image;
        itCanHeal = symptoms;

        foreach(string symptom in itCanHeal)
        {
            cardDescription = cardDescription + "\n •" + symptom;
        }
        
    }
}
