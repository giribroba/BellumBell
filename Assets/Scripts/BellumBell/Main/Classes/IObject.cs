using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObject : MonoBehaviour, IInteract
{
    public void Interact()
    {
        print("Funcionou!!");
    }
}
