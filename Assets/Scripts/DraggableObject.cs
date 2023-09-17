using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _startYPos;
    private BoardController _board;
    private SpriteRenderer _spriteRenderer;
    private int _defaultSortingOrder; // Store the default sorting order of the card
    private Canvas _canvas;
    private CardToHand cth;
    
    void Start()
    {
        _board = GetComponentInParent<BoardController>();
        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _canvas = GetComponentInChildren<Canvas>();


        if (_canvas != null)
        {
            // The Canvas component is found
            // You can now access and modify its properties
            _canvas.enabled = true;
        }
        else
        {
            // The Canvas component is not found
            // Handle the situation accordingly
            Debug.LogError("Canvas component not found!");
        }
 
        _startYPos = 0; // Better to not hardcode that one but whatever

        // Store the default sorting order
        _defaultSortingOrder = _spriteRenderer.sortingOrder;
    }

    private void Update()
    {
        // Adjust sorting order based on Y position of the card
        //_spriteRenderer.sortingOrder = _defaultSortingOrder + Mathf.RoundToInt(transform.position.y) + 1;
        //_canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;
        
    }
 
    public void OnMouseDrag()
    {
        _board = GetComponentInParent<BoardController>();
        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer =  GetComponentInChildren<SpriteRenderer>();
        _canvas = GetComponentInChildren<Canvas>();

        Vector3 newWorldPosition = new Vector3(_board.CurrentMousePosition.x, _startYPos + 1, _board.CurrentMousePosition.z);
 
        var difference = newWorldPosition - transform.position;
 
        var speed = 3 * difference;
        _rigidbody.velocity = speed;
        _rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));

        // Increase the sorting order to ensure the hovering card is on top
        _spriteRenderer.sortingOrder = _defaultSortingOrder + 10;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;
        

    }

    public void OnMouseDrag(Rigidbody rigidBody)
    {
        _board = GetComponentInParent<BoardController>();
        _rigidbody = rigidBody;
        _spriteRenderer =  GetComponentInChildren<SpriteRenderer>();
        _canvas = GetComponentInChildren<Canvas>();

        Vector3 newWorldPosition = new Vector3(_board.CurrentMousePosition.x, _startYPos + 0.5f, _board.CurrentMousePosition.z);
 
        var difference = newWorldPosition - transform.position;
 
        var speed = 10 * difference;
        _rigidbody.velocity = speed;
        _rigidbody.rotation = Quaternion.Euler(new Vector3(speed.z, 0, -speed.x));

        // Increase the sorting order to ensure the hovering card is on top
        _spriteRenderer.sortingOrder = _defaultSortingOrder + 10;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;
        

    }


    public void OnMouseUp()
    {
        // Reset the sorting order to the default value when the card is released
        _spriteRenderer.sortingOrder = _defaultSortingOrder;
        _canvas.sortingOrder = _spriteRenderer.sortingOrder + 1;
        //cth.enabled = true;
    }

    public void ChangeParentToObject(Transform givenParentTransform)
    {
        // Get the transform component of the card
        Transform cardTransform = this.transform;

        // Set the parent of the card to be the parent object
        cardTransform.SetParent(givenParentTransform);

    }
}