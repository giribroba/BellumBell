using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    GameManager gameManager;
    List<Player> players;
    struct Player {
        List<CardsInfo> Hand,BoardHand;     
        }

    void Start()
    {
    }

    void Update()
    {
    }

    
}
