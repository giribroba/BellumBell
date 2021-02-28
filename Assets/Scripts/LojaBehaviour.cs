using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaBehaviour : MonoBehaviour
{
    public GameObject[,] itens;
    public int linhas,colunas;
    public float distanciamentoX,distanciamentoY,offsetX,offsetY;
    public GameObject PLACEHOLDER;
    Vector3 posicaoCameraInicial,AngulacaoInicial;
    
    void EntrandoLoja()
    {
        Camera.main.GetComponent<CameraBehaviour>().SetPosicaoCamera(posicaoCameraInicial,AngulacaoInicial);
    }
    void Awake()
    {
        itens = new GameObject[linhas,colunas];
        DeclararItens();
    }
    void DeclararItens()
    {
        for(int i = 0;i<itens.GetLength(0);i++)
        {
            for(int k = 0;k<itens.GetLength(1);k++)
            {
                itens[i,k] = Instantiate(PLACEHOLDER);
                itens[i,k].transform.position = transform.position + new Vector3(distanciamentoX * k + offsetX,distanciamentoY * i + offsetY);
                itens[i,k].transform.eulerAngles = new Vector3(15,0,0);
                itens[i,k].transform.name = i.ToString() + k.ToString();
            }    
        }

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            EntrandoLoja();
        }
    }
}
