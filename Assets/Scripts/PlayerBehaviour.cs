using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controle;
    public CinemachineFreeLook cinemachine;
    public Canvas JoystickCanvasMobile;
    public float velocidade;
    public float tempoSuavidade;
    Joystick joyPlayer,joyCamera;
    float velocidadeCorrida;
    float tornarSuave;
    float v,h;
    void Awake()
    {
       #if UNITY_ANDROID //|| UNITY_EDITOR
        Canvas joysticks = Instantiate(JoystickCanvasMobile);
        joysticks.worldCamera = Camera.main;
        joyPlayer = joysticks.transform.GetChild(2).GetComponent<Joystick>();
        joyCamera = joysticks.transform.GetChild(1).GetComponent<Joystick>();
        cinemachine.m_YAxis.m_InputAxisName ="";
        cinemachine.m_XAxis.m_InputAxisName ="";
        velocidade = velocidade * 1.05f;
        #endif
    }
    void Start()
    {
        velocidadeCorrida = velocidade;
    }

    void Update()
    {
        Movimentacao();
    }
    public void BotaoInteracaoApertado()
    {
        print("pei pou");
    }
    void Movimentacao()
    {

        Vector3 movimento = Vector3.zero;

        #if UNITY_STANDALONE
        v = Input.GetAxis("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        velocidadeCorrida = Mathf.Clamp(Input.GetKey(KeyCode.LeftShift)? velocidadeCorrida  + Time.deltaTime * 80  : velocidadeCorrida,velocidade ,velocidade*2);
        #endif

        #if UNITY_ANDROID  // || UNITY_EDITOR
        v = joyPlayer.Vertical;
        cinemachine.m_YAxis.Value += joyCamera.Vertical/60;
        cinemachine.m_XAxis.Value += joyCamera.Horizontal;
        h = joyPlayer.Horizontal;
        velocidadeCorrida = Mathf.Clamp(velocidadeCorrida  + Time.deltaTime * 80  ,velocidade ,velocidade*2f);
        #endif
        
        velocidadeCorrida -= Time.deltaTime *40;
        //caso ele fique parado em uma parede apertando w + shift, ele ja não saia correndo sem antes acelerar
        velocidadeCorrida = controle.velocity.magnitude <= 33 ? velocidade : velocidadeCorrida;

        transform.Rotate(Vector3.up *h *velocidadeCorrida /(velocidade +10)* Time.deltaTime * 150); 

        transform.GetComponent<Animator>().SetFloat("Velocidade",controle.velocity.magnitude * v);

        movimento += 
        transform.forward*
        Mathf.Clamp(v * velocidadeCorrida,-velocidade,velocidade * 2)*
        Time.deltaTime;

        movimento += Physics.gravity/20;

        controle.Move(movimento);
     
    }
}
