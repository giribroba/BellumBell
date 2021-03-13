using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controle;
    public Transform cam;
    public float velocidade;
    public float tempoSuavidade;
    float tornarSuave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
    void Movimentacao()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direcao = new Vector3(horizontal,0f,vertical).normalized;
        transform.GetComponent<Animator>().SetFloat("Velocidade", direcao.magnitude);
        
        if(direcao.magnitude >=0.01f)
        {
            float OlhandoPara = Mathf.Atan2(direcao.x,direcao.z)* Mathf.Rad2Deg +cam.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y,OlhandoPara,ref tornarSuave, tempoSuavidade);
            transform.rotation = Quaternion.Euler(Vector3.up * angulo);

            Vector3 movDir = Quaternion.Euler(0f,OlhandoPara,0f)* Vector3.forward;
            controle.Move(movDir.normalized*velocidade*Time.deltaTime);
            
        }
    }
}
