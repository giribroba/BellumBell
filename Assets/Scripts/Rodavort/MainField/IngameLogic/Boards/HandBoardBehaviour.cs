﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBoardBehaviour : MonoBehaviour
{
    List<Card> handBoard = new List<Card>();

    [Header("Board Refferences")]
    [SerializeField] HandBehaviour handBehave;
    [SerializeField] GameObject cardPrefab;

    [Header("Board Settings")]

    [SerializeField] float boardMaxWidth;
    [SerializeField] float maxHandAngle;
    [SerializeField] float handWidthMultiplier;
    [SerializeField] float handSizeIncreaseValue;

    [Header("Board Offset")]
    [SerializeField] Vector2 handOffset;
    [SerializeField] float ZangleOffSet;
  
    float handXAxisWidth;

    //const int MaxCardInHand = 10; dont have max limit yet

    HandBehaviour.HandAnimationSettings boardAnimationSettings;
    Coroutine organizeHandCurrentCoroutine;

    
    void Start() 
    {
        boardMaxWidth /= handWidthMultiplier;

        boardAnimationSettings = new HandBehaviour.HandAnimationSettings(handOffset,ZangleOffSet,maxHandAngle,handWidthMultiplier,handXAxisWidth,true);
        
    }
    public int GetHandCount{get => handBoard.Count;}


    public void CreateCard(Card card)
    {
        
        Card newBoardCard = card.OnHandBoardInstantiate(this.transform);

        if(!newBoardCard) return;

        CardAnimation cardAnim = newBoardCard.transform.GetComponent<CardAnimation>();

        newBoardCard.ReceiveStartInfo(card.initialInfo);

        handBoard.Add(newBoardCard);

        float boardWidth = (handBoard.Count-1) * handSizeIncreaseValue;

        //limit of Width
        boardAnimationSettings.HandXAxisWidth = Mathf.Clamp(boardWidth,-boardMaxWidth/2,boardMaxWidth/2); 

        StartCoroutine(cardAnim.Dissolve(true));  
        
        OrganizeBoard();

    }
    public void OrganizeBoard()
    {
        if (organizeHandCurrentCoroutine != null) {StopCoroutine(organizeHandCurrentCoroutine);}
        organizeHandCurrentCoroutine = StartCoroutine(handBehave.OrganizeHandAnim(boardAnimationSettings,handBoard));

    }
   void DoSpellThings(){
       //example
    }
    public Vector2 CalculeCardFinalPosition(int handCount)
    {    
        float widthIncreaseConst = boardAnimationSettings.HandXAxisWidth / (handCount-1);
        float concat = -boardAnimationSettings.HandXAxisWidth;

        concat += concat + (handCount != 1 ? widthIncreaseConst * handCount * 2: 0);
        return  new Vector2((handCount != 1 ? boardAnimationSettings.HandXAxisWidth * boardAnimationSettings.WidthMultiplier: 0) ,boardAnimationSettings.OffSet.y + (-Mathf.Abs(concat)/(boardAnimationSettings.Angulation*15)));

    }
}
