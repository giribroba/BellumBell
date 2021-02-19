using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PixelController : MonoBehaviour
{
    public Material materialAfetado;
    public float speed;
    int propX,propY;
    float loaded ;

    void Start()
    {
        propX= 256; 
        propY= 144;
        InvokeRepeating("Transicao",0,speed/100);
    }
    void Transicao()
    {
        loaded += speed;
        print(loaded);
        if(loaded >= 1)
        {
            CancelInvoke("Transicao");
            propX= 256; 
            propY= 144;
            materialAfetado.SetFloat("_Linhas", propX * loaded);
            materialAfetado.SetFloat("_Colunas", propY * loaded);
        }

        materialAfetado.SetFloat("_Linhas", propX * loaded);
        materialAfetado.SetFloat("_Colunas", propY * loaded);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnRenderImage(RenderTexture origem,RenderTexture destinado)
    {
        Graphics.Blit(origem,destinado,materialAfetado);
    }
}
