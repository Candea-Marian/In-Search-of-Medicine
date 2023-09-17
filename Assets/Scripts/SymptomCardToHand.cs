using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SymptomCardToHand : MonoBehaviour
{

    private GameObject Table;
    public GameObject EnemyHand;
    public GameObject EnemyHandCard; 
    private SpriteRenderer _spriteRenderer;
    private int _defaultSortingOrder; // Store the default sorting order of the card
    private Canvas _canvas;

    private Vector3 cardPositionHand = new Vector3(0,0,982.813293f);
    private Vector3 cardRotationHand = new Vector3(270.019775f,-9.43778869e-05f,0);
    private Vector3 cardScaleHand = new Vector3(8557.43457f,1077.83276f,2843.06152f);

    // Start is called before the first frame update
    void Start()
    {
        EnemyHand = GameObject.Find("EnemyHand");
        Table = GameObject.Find("Table");

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _canvas = GetComponentInChildren<Canvas>();
        _canvas.sortingLayerName = "card-info";
        _spriteRenderer.sortingLayerName = "card-info";

        _defaultSortingOrder = _spriteRenderer.sortingOrder;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;

        ChangeParentToObject(EnemyHand.transform);
        EnemyHandCard.transform.localScale = cardScaleHand;
        EnemyHandCard.transform.localPosition = cardPositionHand;
        EnemyHandCard.transform.localRotation = Quaternion.Euler(cardRotationHand);

        //Damage
        //TextMeshProUGUI nameText = GetComponentInChildren<NameText>();
        int damage = GetComponentInChildren<DisplaySymptomCard>().attackDamage;
        ClientHP.staticHealth -= damage;
        Debug.Log("Attack damage: " + damage);
        Debug.Log("name: "  );
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeParentToObject(Transform givenParentTransform)
    {
        // Get the transform component of the card
        Transform cardTransform = EnemyHandCard.transform;

        // Set the parent of the card to be the parent object
        cardTransform.SetParent(givenParentTransform);

    }
}
