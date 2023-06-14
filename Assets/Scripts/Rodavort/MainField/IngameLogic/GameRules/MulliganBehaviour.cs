using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulliganBehaviour : MonoBehaviour
{
     [SerializeField] HandBehaviour mulliganHand;

     void Start()
     {
          int[] abc = {1,2,3};
          ShowCardOptions(abc);
     }
     void ShowCardOptions(int[] cardIds)
     {

          for(uint i = 0; i < cardIds.Length ;i++)
          {
               print(i);
          }

     }

}
