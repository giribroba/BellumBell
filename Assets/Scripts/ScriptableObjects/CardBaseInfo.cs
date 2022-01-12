using UnityEngine;

public class CardBaseInfo : ScriptableObject
{
    public uint cardId;
    public TypeCard typecard;

    [Header("Reading")]
    public Sprite design;

}
public enum TypeCard { Minion, Spell }