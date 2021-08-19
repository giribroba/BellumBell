using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    CharacterBehaviour player;
    UIManager ui;
    void Awake()
    {
        ui = GetComponent<UIManager>();
        player = (CharacterBehaviour)FindObjectOfType(typeof(CharacterBehaviour));
    }

    void Start()
    {
        player.GamePaused += ui.Pause;
    }
}
