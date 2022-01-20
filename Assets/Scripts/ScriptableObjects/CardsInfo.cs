using UnityEngine;

public class CardsInfo : ScriptableObject
{
    public uint cardId;
    public TypeCard typeCard;

    [Header("Reading")]
    public Sprite design;
        
    [Header("Attributes")]
    public int gold;
    public int life;
    public int power;

    [Header("Dubbing")]
    public AudioClip[] SoundAtEntrance;
    public AudioClip[] SoundInDeath;
}
public enum TypeCard { Minion, Spell }