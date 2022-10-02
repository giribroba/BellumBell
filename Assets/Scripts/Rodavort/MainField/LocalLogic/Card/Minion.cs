using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Card

{
    int life, power;
    int Power
    {
        get => power;
        set
        {
            power = value;
            powerText.text = power.ToString();
        }
    }

    int Life
    {
        get => life;
        set
        {
            life = value;
            lifeText.text = life.ToString();
        }
    }

    public override void ReceiveStartInfo(CardsInfo info)
    {
        base.ReceiveStartInfo(info);
 
        Life = info.life;
        Power = info.power;

    }
    public override Card OnHandBoardInstantiate(Transform boardTransform)
    {
        GameObject minionPrefab = Resources.Load<GameObject>("Cards/Prefabs/MinionBoardCard");
        minionPrefab = Instantiate(minionPrefab, boardTransform);
        
        return minionPrefab.transform.GetChild(0).GetComponent<Minion>();;
    }
}