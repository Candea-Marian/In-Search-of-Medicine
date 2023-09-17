using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    private GameObject Table;
    public GameObject HandCard; 
    private SpriteRenderer _spriteRenderer;
    private int _defaultSortingOrder; // Store the default sorting order of the card
    private Canvas _canvas;

    private Vector3 cardPositionHand = new Vector3(0,0,982.813293f);
    private Vector3 cardRotationHand = new Vector3(270.019775f,-9.43778869e-05f,0);
    private Vector3 cardScaleHand = new Vector3(8557.43457f,1077.83276f,2843.06152f);
    private DraggableObject dro;
    private GameObject ActionZone;
    private GameObject EnemyHand;
    public AudioSource audiosource;
    public AudioClip destroyClip;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null)
        {
            return;
        }

        CardToHand card = eventData.pointerDrag.GetComponent<CardToHand>();
        DisplayCard cardDisplayInfo = card.GetComponent<DisplayCard>();
        int cardMentalCost = cardDisplayInfo.mentalCost;
        int cardAttackDamage = cardDisplayInfo.attackDamage;
        int cardHealthPoints = cardDisplayInfo.health;
        List<string> itCanHeal = cardDisplayInfo.itCanHeal;
        if(card != null && cardMentalCost <= TurnSystem.currentMentalEnergy)
        {
            TurnSystem.currentMentalEnergy -= cardMentalCost;
            card.returnToParent = ActionZone.transform;
            ClientHP.staticHealth += cardHealthPoints; //client health increases if any card is played

            for (int i = 0; i < EnemyHand.transform.childCount; i++)
            {
                // Get the child at the current index
                GameObject symptomCard = EnemyHand.transform.GetChild(i).gameObject;
                DisplaySymptomCard symptomCardDisplayInfo = symptomCard.GetComponent<DisplaySymptomCard>();
                string symptomName = symptomCardDisplayInfo.cardName;
                int symptomDamage = symptomCardDisplayInfo.attackDamage;
                int symptomHealth = symptomCardDisplayInfo.health;
                foreach(string symptom in itCanHeal)
                {
                    if(Equals(symptom, symptomName))
                    {
                        int tempDamage = symptomDamage;
                        symptomDamage -= cardAttackDamage;
                        cardAttackDamage -= tempDamage;

                        if(symptomDamage <= 0)
                        {
                            Destroy(symptomCard.gameObject);
                        }
                        else
                        {
                            symptomCard.GetComponent<DisplaySymptomCard>().attackDamage = symptomDamage;
                            Debug.Log("symptom damage:" + symptomDamage);
                        }

                        if(cardAttackDamage <= 0)
                        {
                            Destroy(card.gameObject);
                        }
                        else
                        {
                            card.GetComponent<DisplayCard>().attackDamage = cardAttackDamage;
                        }
                        
                        
                        audiosource.PlayOneShot(destroyClip);
                    }
                }

                // Do something with the child
                //Debug.Log("Child Name: " + symptomCardTransform.GetComponent<DisplaySymptomCard>().cardName);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        ActionZone = GameObject.Find("ActionZone");
        EnemyHand = GameObject.Find("EnemyHand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
