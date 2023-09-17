using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardToHand : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private GameObject Table;
    public GameObject Hand;
    public GameObject HandCard; 
    private SpriteRenderer _spriteRenderer;
    private int _defaultSortingOrder; // Store the default sorting order of the card
    private Canvas _canvas;

    private Vector3 cardPositionHand = new Vector3(0, 0, 936.637268f);
    private Vector3 cardRotationHand = new Vector3(270, 0, 0);
    private Vector3 cardScaleHand = new Vector3(8557.43457f, 1077.83301f, 2843.06152f);

    private Vector3 startPosition;

    private DraggableObject dro;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private bool isDragging = false;
    private bool isMouseDown = false;

    public Transform returnToParent;


    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");
        Table = GameObject.Find("Table");

        returnToParent = Hand.transform;
        dro = GetComponent<DraggableObject>();

        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _canvas = GetComponentInChildren<Canvas>();
        _canvas.sortingLayerName = "card-info";
        _spriteRenderer.sortingLayerName = "card-info";

        _defaultSortingOrder = _spriteRenderer.sortingOrder;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;

        ChangeParentToObject(returnToParent);
        HandCard.transform.localScale = cardScaleHand;
        HandCard.transform.localPosition = cardPositionHand;
        HandCard.transform.localRotation = Quaternion.Euler(cardRotationHand);

        _rigidbody.isKinematic = true;
        _boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMouseDown && isDragging)
        {
            _spriteRenderer.sortingOrder = _defaultSortingOrder + 2;
            _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;

            // If you need to force a layout update, use the following lines:
            //LayoutRebuilder.ForceRebuildLayoutImmediate(Hand.GetComponent<RectTransform>());
            Canvas.ForceUpdateCanvases();
           
            startPosition = HandCard.transform.position;

            dro.OnMouseDrag(_rigidbody);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        _rigidbody.isKinematic = false;
        _boxCollider.enabled = true;

        ChangeParentToObject(Table.transform);
        

        startPosition = HandCard.transform.position;

        // Increase the Y position of the card
        Vector3 newPosition = HandCard.transform.position;
        newPosition.y = 1;
        HandCard.transform.position = newPosition;
        isDragging = true;
        isMouseDown = true;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //isHoldingCard = true;
        //dro.OnMouseDrag(_rigidbody);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        ChangeParentToObject(returnToParent);
        HandCard.transform.localScale = cardScaleHand;
        HandCard.transform.localPosition = cardPositionHand;
        HandCard.transform.localRotation = Quaternion.Euler(cardRotationHand);
        _rigidbody.isKinematic = true;
        _boxCollider.enabled = false;

        isDragging = false;
        isMouseDown = false;

        _canvas.sortingLayerName = "card-info";
        _spriteRenderer.sortingLayerName = "card-info";
        _spriteRenderer.sortingOrder = _defaultSortingOrder;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }



    public void ChangeParentToObject(Transform givenParentTransform)
    {
        // Get the transform component of the card
        Transform cardTransform = HandCard.transform;

        // Set the parent of the card to be the parent object
        cardTransform.SetParent(givenParentTransform);

    }
}
