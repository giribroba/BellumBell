﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardInput :  MonoBehaviour ,IPointerExitHandler, IPointerEnterHandler,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Card actualCard;
    
    PlayerBehaviour player;
    HandInput handBoard;
    HandBehaviour playerHand;
    
    float handlingCardSize = 0.7f;
    
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        playerHand = GameObject.Find("PlayerHand").GetComponent<HandBehaviour>();
        handBoard = playerHand.GetComponent<HandInput>();
      
    }
    public void OnPointerEnter(PointerEventData eventData)
    {   
   
        actualCard.ChangeSize(playerHand.showingHandSize + 0.1f,10);
        transform.SetAsLastSibling();
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {  
        if(!eventData.dragging)
        {
            transform.SetSiblingIndex(actualCard.posInHand);
            actualCard.ChangeSize(playerHand.showingHandSize,10);
            if(!handBoard.pointerOnBoard)
                playerHand.StopShowingAmplifiedHand();
        }
    }

   public void OnBeginDrag(PointerEventData eventData)
    {
        playerHand.SetCardsHandRaycast(false);
        handBoard.SetHandRaycast(false);
        GetComponent<Image>().raycastTarget = false;
        
        transform.SetAsLastSibling();
        transform.GetChild(0).rotation = Quaternion.identity;

        actualCard.ChangeSize(handlingCardSize, 2f);
        playerHand.RemoveCard(actualCard.posInHand);   
        
    }
    public void OnDrag(PointerEventData eventData) { 
        Debug.Log("Drag");
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,100)) ;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
          Debug.Log("endDrag");
        if(eventData.hovered.Count>0)
        {
              Debug.Log("endDragR");
            foreach(var parents in eventData.hovered)
                if(parents.gameObject.tag == "PlayerBoard")
                {
                    player.PutCardOnBoard(actualCard);

                    playerHand.SetCardsHandRaycast(true);
                    handBoard.SetHandRaycast(true);

                    return;
                }
                
        }

        ReturnCardToHand();
     
    }
    void ReturnCardToHand()
    {
        playerHand.AddCard(actualCard.posInHand,actualCard);
        transform.SetSiblingIndex(actualCard.posInHand);
        handBoard.SetHandRaycast(true);
    }
}
