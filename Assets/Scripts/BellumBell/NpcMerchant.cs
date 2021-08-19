using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMerchant : MonoBehaviour, INPC
{
    public void Interact()
    {
        Dialogue();
    }
    public void Dialogue()
    {
        print("hi");
    }
}
