using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardUnit : MonoBehaviour, IPointerClickHandler
{
    private bool isInteractable = true;
    
    private Image image;
    private int? type = null;
    public static UnityAction<BoardUnit> OnInteracted { get; set;}

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isInteractable)
            return;
        
        isInteractable = false;
        GameBoardController.Instance.HandleOnInteracted(this);
    }

    public void SetImage(Sprite image)
    {
        this.image.sprite = image;
    }

    public void SetType(int target) => this.type = target;
    public int? GetType => type;
    
    
}
