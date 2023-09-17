using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Disease
{
    
    public int id;
    public string diseaseName;
    public List<SymptomCard> symptoms = new List<SymptomCard>();

    public Disease()
    {

    }

    public Disease(int identifier, string name, List<SymptomCard> cards)
    {
        id = identifier;
        diseaseName = name;
        symptoms = cards;
    }


}
