using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomCardDatabase : MonoBehaviour
{
    public static List<SymptomCard> symptomCardList = new List<SymptomCard>();
    void Awake() {
        symptomCardList.Add(new SymptomCard(0, "Sore Throat", 3, 1, 2));

        symptomCardList.Add(new SymptomCard(1, "Runny Nose", 1, 2, 1));

        symptomCardList.Add(new SymptomCard(2, "Sneezing", 1, 2, 1));

        symptomCardList.Add(new SymptomCard(3, "Nausea", 1, 5, 3));
    }
}
