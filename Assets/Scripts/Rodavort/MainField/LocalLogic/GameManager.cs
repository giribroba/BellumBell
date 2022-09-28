using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    [Header("Players Managers")]
    [SerializeField] PlayerBehaviour currentPlayer;
    [SerializeField] PlayerBehaviour adversaryPlayer;

    [SerializeField] MulliganBehaviour mulligan;


    enum GameState 
    {
        StartGame,
        CoinFlip,
        Mulligan,
        PlayerOne,
        PlayerTwo,
        EndGame
    }
    void EnemyPutCardOnBoard(/*CardsInfo cardInfo,*/int posInHand)
    {   

        if(adversaryPlayer.hand.handActualCount == 0) return;

        Card removedCard = adversaryPlayer.hand.RemoveCard(adversaryPlayer.hand.handActualCount-1);

        adversaryPlayer.hand.OrganizeHand();

        //needs server manager to work completly in multiplayer
        //removedCard.ReceiveStartInfo(cardInfo);

        adversaryPlayer.PutCardOnBoard(removedCard);
    }
    void Update()
    {
        //WILL BE REMOVE ON REALESE (TEST ONLY)
        if(Input.GetKeyDown(KeyCode.A))
        {
            EnemyPutCardOnBoard(0);
        }
    }
    

}
