using UnityEngine;

[CreateAssetMenu(fileName = "New Card",menuName = "Card/Spell")]
public class SpellInfo : CardBaseInfo
{

    [Header("Attributes")]
    public int gold;

    [Header("Dubbing")]
    public AudioClip[] SoundAtEntrance;
}