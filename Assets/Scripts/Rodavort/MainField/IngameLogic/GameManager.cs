using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    [Header("Players Managers")]
    [SerializeField] PlayerBehaviour currentPlayer;
    [SerializeField] PlayerBehaviour adversaryPlayer;

    [SerializeField] MulliganBehaviour mulligan;
    private GameStatus gameState;
    public enum GameStatus 
    {
        StartGame,
        CoinFlip,
        Mulligan,
        PlayerOne,
        PlayerTwo,
        EndGame
    }
    public GameStatus GameState
    {
        get {return gameState;}
        set {
                gameState = value;
                
                print($"GameState changed to: {gameState}");
                Invoke(gameState.ToString(), 0);
            }
    }

    void CoinFlip()
    {
        print("MOEDA GIROU");
    }
    public void EnemyPutCardOnBoard(/*CardsInfo cardInfo,*/int posInHand)
    {   

        if(adversaryPlayer.hand.handActualCount == 0) return;

        Card removedCard = adversaryPlayer.hand.RemoveCard(adversaryPlayer.hand.handActualCount-1);

        adversaryPlayer.hand.OrganizeHand();

        //needs server manager to work completly in multiplayer
        //removedCard.ReceiveStartInfo(cardInfo);

        adversaryPlayer.PutCardOnBoard(removedCard);
    }
    
}
