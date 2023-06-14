using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public float velocidadeAnimacao = 1f;
    float x,y;
    bool seguirPlayer;


    public Vector3   PosicaoInicial
    {
        get;set;        
    }
    public Vector3 PosicaoFinal
    {
        get;set;        
    }
    public Vector3 AngulacaoInicial
    {
        get;set;        
    }

    public Vector3 AngulacaoFinal
    {
        get;set;        
    }
    public void SetPosicaoCamera(Vector3 novaPosicaoF,Vector3 novaAngulacaoF)
    {
        if(seguirPlayer)
            return;

        AngulacaoInicial = transform.eulerAngles;
        PosicaoInicial = transform.position;

        AngulacaoFinal = novaAngulacaoF;
        PosicaoFinal = novaPosicaoF;
        
        x = 0;

        StartCoroutine("MovimentarCamera");


    }
    IEnumerator MovimentarCamera() {
        while(x<= 1){

            x += (velocidadeAnimacao * Time.deltaTime);
            y = -x * x + 2 * x;
            
            Quaternion newEulerAngle = Quaternion.Euler(AngulacaoFinal);
            transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, newEulerAngle,x/10);
            transform.localPosition = Vector3.Lerp(PosicaoInicial,PosicaoFinal, y);
            yield return null;
       } 
  
    }
}
