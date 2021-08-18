using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PixelController : MonoBehaviour
{
    public Material materialAfetado;
    public float speed;
    int propX,propY;
    float loaded;

    void Start()
    {
        propX= 180; 
        propY= 320;
        InvokeRepeating("Transicao",0,speed/20);
    }
    void Transicao()
    {
        loaded += speed;
        if(loaded >= 1)
        {
            CancelInvoke("Transicao");
            propX= 180; 
            propY= 320;
            materialAfetado.SetFloat("_Linhas", propX);
            materialAfetado.SetFloat("_Colunas", propY);
            return; 
        }

        materialAfetado.SetFloat("_Linhas", propX * loaded);
        materialAfetado.SetFloat("_Colunas", propY * loaded); 
        
    }

    void OnRenderImage(RenderTexture origem,RenderTexture destinado)
    {
        Graphics.Blit(origem,destinado,materialAfetado);
    }
}
