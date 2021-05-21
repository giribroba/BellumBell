using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBheaviour : MonoBehaviour
{
  
    public void Interacao()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().BotaoInteracao_A();
    }
    public void InteracaoB()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().BotaoInteracao_B();
    }
}
