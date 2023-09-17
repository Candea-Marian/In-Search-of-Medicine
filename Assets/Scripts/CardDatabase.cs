using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    void Awake() {
        Sprite sp = Resources.Load<Sprite>("PlantIlustrations/Chamomile");
        cardList.Add(new Card(0, "Chamomile", 3, 1, 1, new List<string>(){"Digestive Issues", "Anxiety", "Skin Irritation"}, sp));

        sp = Resources.Load<Sprite>("PlantIlustrations/Echinacea");
        cardList.Add(new Card(1, "Echinacea", 1, 1, 1, new List<string>(){"Sore Throat", "Immune Weakness"}, sp));

        sp = Resources.Load<Sprite>("PlantIlustrations/Ginger");
        cardList.Add(new Card(2, "Ginger", 2, 5, 1, new List<string>(){"Nausea", "Digestive Issues", "Headache"}, sp));

        sp = Resources.Load<Sprite>("PlantIlustrations/Lavender2");
        cardList.Add(new Card(3, "Lavender", 4, 0, 1, new List<string>(){"Insomnia", "Anxiety", "Stress"}, sp));

        sp = Resources.Load<Sprite>("PlantIlustrations/lemonbalm");
        cardList.Add(new Card(4, "Lemon Balm", 3, 3, 1, new List<string>(){"Runny Nose", "Sneezing"}, sp));
    }
}
