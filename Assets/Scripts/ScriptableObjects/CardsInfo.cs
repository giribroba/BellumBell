using UnityEngine;

[CreateAssetMenu(fileName = "New Card",menuName = "Card/Minion")]
public class CardsInfo : CardBaseInfo
{
    
    [Header("Attributes")]
    public int gold;
    public int life;
    public int power;

    [Header("Dubbing")]
    public AudioClip[] SoundAtEntrance;
    public AudioClip[] SoundInDeath;

}
