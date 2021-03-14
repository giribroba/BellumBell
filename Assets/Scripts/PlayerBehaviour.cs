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
      Vector3 movement = Vector3.zero;
      float v = Input.GetAxis("Vertical");
      float h = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up *h);
      transform.GetComponent<Animator>().SetFloat("Velocidade",controle.velocity.magnitude);
      movement += transform.forward * v * velocidade * Time.deltaTime;
      controle.Move(movement);
      //movement += transform.right * h * velocidade * Time.deltaTime;
      //movement = transform.TransformDirection(movement);
      movement += Physics.gravity;
      
    }
}
