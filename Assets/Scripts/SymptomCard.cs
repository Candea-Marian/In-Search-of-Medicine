using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SymptomCard
{
    
    public int id;
    public string cardName;
    public int mentalCost;
    public int attackDamage;
    public int health;

    public SymptomCard()
    {

    }

    public SymptomCard(int identifier, string name, int cost, int damage, int healthPoints)
    {
        id = identifier;
        cardName = name;
        mentalCost = cost;
        attackDamage = damage;
        health = healthPoints;
    }


}
