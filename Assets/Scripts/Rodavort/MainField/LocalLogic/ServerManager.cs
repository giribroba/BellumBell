using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    List<Player> players;
    struct Player {
        List<CardsInfo> Hand,BoardHand;     
        }

    void Start()
    {
        // Do something important before the game start
        gameManager.GameState = GameManager.GameStatus.StartGame;
        // Game starts
        gameManager.GameState = GameManager.GameStatus.CoinFlip;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameManager.EnemyPutCardOnBoard(0);
        }
    }

    
}
