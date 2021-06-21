using Cinemachine;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController control;
    public CinemachineFreeLook cinemachine;
    public Canvas JoystickCanvasMobile;
    public float normalSpeed;
    public float suavityTime;
    Joystick joyPlayer, joyCamera;
    float runSpeed;
    float v, h;
    float moveTime;
    [SerializeField] AnimationCurve speedCurve;
    Quaternion targetRotation;
    [SerializeField] float rotationSpeed;
    Vector3 moviment;
    void Awake()
    {
#if UNITY_ANDROID
        Canvas joysticks = Instantiate(JoystickCanvasMobile);
        joysticks.worldCamera = Camera.main;
        joyPlayer = joysticks.transform.GetChild(2).GetComponent<Joystick>();
        joyCamera = joysticks.transform.GetChild(3).GetComponent<Joystick>();
        cinemachine.m_YAxis.m_InputAxisName ="";
        cinemachine.m_XAxis.m_InputAxisName ="";
        velocidade = velocidade * 1.05f;
#endif
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        runSpeed = normalSpeed;
    }

    void Update()
    {

        Movimentacao();
    }
    public void BotaoInteracao_A()
    {
        print("pei pou");
    }
    public void BotaoInteracao_B()
    {
        print("POOOOOOOOOUW");
    }

    void Movimentacao()
    {

        //Vector3 movimento = Vector3.zero;

#if UNITY_STANDALONE
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        runSpeed = Input.GetKey(KeyCode.LeftShift) ? normalSpeed * 2 : normalSpeed;
#endif

#if UNITY_ANDROID
        v = joyPlayer.Vertical;
        cinemachine.m_YAxis.Value += joyCamera.Vertical/60;
        cinemachine.m_XAxis.Value += joyCamera.Horizontal;
        h = joyPlayer.Horizontal;
        velocidadeCorrida = Mathf.Clamp(velocidadeCorrida  + Time.deltaTime * 80  ,velocidade ,velocidade*2f);
#endif

        //caso ele fique parado em uma parede apertando w + shift, ele ja não saia correndo sem antes acelerar
        //runSpeed = control.velocity.magnitude <= 33 ? normalSpeed : runSpeed;

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            targetRotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y + Mathf.Atan(h / v) * 180 / Mathf.PI + (v < 0 ? 180 : 0), 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            moveTime = (moveTime >= 1? 1 : moveTime + Time.deltaTime);
        }
        else
        {
            moveTime = (moveTime <= 0 ? 0 : moveTime - 4*Time.deltaTime);
        }

        moviment = transform.forward * speedCurve.Evaluate(moveTime) * runSpeed * Time.deltaTime;
        
        transform.GetComponent<Animator>().SetFloat("Velocidade", control.velocity.magnitude);

        moviment += Physics.gravity / 20;

        control.Move(moviment);

    }
}
