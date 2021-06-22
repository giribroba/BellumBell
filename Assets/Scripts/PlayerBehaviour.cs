using Cinemachine;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController control;
    public CinemachineVirtualCamera cinemachine;
    CinemachinePOV POV;
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
    Vector3 movement;
    void Awake()
    {
#if UNITY_ANDROID
        Canvas joysticks = Instantiate(JoystickCanvasMobile);
        joysticks.worldCamera = Camera.main;
        joyPlayer = joysticks.transform.GetChild(3).GetComponent<Joystick>();
        POV = cinemachine.AddCinemachineComponent<CinemachinePOV>();
        joyCamera = joysticks.transform.GetChild(2).GetComponent<Joystick>();
        POV.m_HorizontalAxis.m_InputAxisName = "";
        POV.m_VerticalAxis.m_InputAxisName = "";
#else
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
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
#if UNITY_STANDALONE
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
#endif

#if UNITY_ANDROID
        v = joyPlayer.Vertical;
        POV.m_HorizontalAxis.m_InputAxisValue = joyCamera.Horizontal;
        POV.m_VerticalAxis.m_InputAxisValue = joyCamera.Vertical;
        //cinemachine.m_XAxis.Value += joyCamera.Horizontal;
        h = joyPlayer.Horizontal;
        //runSpeed = Mathf.Clamp(runSpeed  + Time.deltaTime * 80  ,speed ,velocidade*2f);
#endif

        if (v != 0 || h != 0)
        {
            var angleOffset = Mathf.Atan(h / v) * 180 / Mathf.PI;
            targetRotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y + (float.IsNaN(angleOffset) ? 0 : angleOffset) + (v < 0 ? 180 : 0), 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveTime = (moveTime >= 1 ? 1 : moveTime + Time.deltaTime);
            }
            else
            {
                moveTime += (moveTime >= 0.5f ? -4 * Time.deltaTime : Time.deltaTime);
            }
        }
        else
        {
            moveTime = (moveTime <= 0 ? 0 : moveTime - 4 * Time.deltaTime);
        }

        print(h);

        movement = transform.forward * speedCurve.Evaluate(moveTime) * normalSpeed * Time.deltaTime;

        transform.GetComponent<Animator>().SetFloat("Velocidade", control.velocity.magnitude);

        movement += Physics.gravity / 20;

        control.Move(movement);

    }
}
