using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controle;
    public float velocidade;
    public float tempoSuavidade;
    float velocidadeCorrida;
    float tornarSuave;
    void Start()
    {
        velocidadeCorrida = velocidade;
    }

    void Update()
    {
        Movimentacao();
    }
    void Movimentacao()
    {

        Vector3 movimento = Vector3.zero;
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        velocidadeCorrida = Mathf.Clamp(Input.GetKey(KeyCode.LeftShift)? velocidadeCorrida  + Time.deltaTime * 80  : velocidadeCorrida,velocidade ,velocidade*2);
        velocidadeCorrida -= Time.deltaTime *40;
        
        //caso ele fique parado em uma parede apertando w + shift, ele ja não saia correndo sem antes acelerar
        velocidadeCorrida = controle.velocity.magnitude <= 33 ? velocidade : velocidadeCorrida;

        transform.Rotate(Vector3.up *h *velocidadeCorrida /(velocidade +10)); 

        transform.GetComponent<Animator>().SetFloat("Velocidade",controle.velocity.magnitude * v);

        movimento += 
        transform.forward*
        Mathf.Clamp(v * velocidadeCorrida,-velocidade,velocidade * 2)*
        Time.deltaTime;

        movimento += Physics.gravity/20;

        controle.Move(movimento);
     
    }
}
