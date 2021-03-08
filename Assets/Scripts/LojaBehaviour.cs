using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaBehaviour : MonoBehaviour
{
    public Vector2 tamanho,distanciamento,offset;
    public GameObject PLACEHOLDER;
    Vector3 posicaoCameraInicial,AngulacaoInicial;
    GameObject[,] itens;  
    
    void EntrandoLoja()
    {
        Camera.main.GetComponent<CameraBehaviour>().SetPosicaoCamera(new Vector3(26,4,38),new Vector3(9.5f,-53f,-0.9f));
    }
    void Awake()
    {
        itens = new GameObject[(int)tamanho.x,(int)tamanho.y];
        DeclararItens();
    }
    void DeclararItens()
    {
        for(int i = 0;i<itens.GetLength(0);i++)
        {
            for(int k = 0;k<itens.GetLength(1);k++)
            {
                itens[i,k] = Instantiate(PLACEHOLDER);
                itens[i,k].transform.position = transform.position + new Vector3(distanciamento.x * k + offset.x,distanciamento.y * i + offset.y);
                itens[i,k].transform.eulerAngles = new Vector3(15,0,0);
            }    
        }

    }
    void Update()
    {
        // atualizar pro new input system   
        // // placeholder test
        // if(Input.GetKeyDown(KeyCode.Z))
        // {
        //     EntrandoLoja();
        // }
    }
}
