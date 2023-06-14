using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card
{
    public override void ReceiveStartInfo(CardsInfo info)
    {
        base.ReceiveStartInfo(info);
         print("i'm a spell");
        // base.initialInfo = info;

        // base.cardId = info.cardId;
        // base.Life = info.life;
        // base.Gold = info.gold;
        // base.Power = info.power;
        // base.design.sprite = info.design;

        // base.nameText.text = JsonReader.TranslateTo(UserPrefs.lenguage).cards[cardId].name;
        // base.descText.text = JsonReader.TranslateTo(UserPrefs.lenguage).cards[cardId].description;

    }
    public override Card OnHandBoardInstantiate(Transform boardTransform)
    {
        print("do spell thing");
        return null;
    }
}
