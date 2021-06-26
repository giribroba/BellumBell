using Cinemachine;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] CharacterController control;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    CinemachinePOV POV;
    [SerializeField] Canvas canvas;
    [SerializeField] float normalSpeed;
    [SerializeField] float suavityTime;
    Joystick joyPlayer, joyCamera;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject mobileHud;
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
        mobileHud.SetActive(true);
        joyPlayer = GameObject.Find("JoystickPlayer").GetComponent<Joystick>();
        POV = cinemachine.AddCinemachineComponent<CinemachinePOV>();
        joyCamera = GameObject.Find("JoystickCamera").GetComponent<Joystick>();
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
        v = joyPlayer.Vertical * 6;
        POV.m_HorizontalAxis.m_InputAxisValue = joyCamera.Horizontal;
        POV.m_VerticalAxis.m_InputAxisValue = joyCamera.Vertical;
        //cinemachine.m_XAxis.Value += joyCamera.Horizontal;
        h = joyPlayer.Horizontal * 6;
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
                moveTime += (moveTime >= 0.5f ? -2 * Time.deltaTime : Time.deltaTime);
            }
        }
        else
        {
            moveTime = (moveTime <= 0 ? 0 : moveTime - 4 * Time.deltaTime);
        }

        movement = transform.forward * speedCurve.Evaluate(moveTime) * normalSpeed * Time.deltaTime;

        transform.GetComponent<Animator>().SetFloat("Velocidade", control.velocity.magnitude);

        movement += Physics.gravity / 20;

        control.Move(movement);   
    }
    private void ShowPanel(GameObject panel)
    {
    }
    private void ClosePanel(GameObject panel)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "AreaTrigger")
        {
            print("1");
            ShowPanel(panel);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AreaTrigger")
        {
            print("2");
            ClosePanel(panel);
        }
    }
}
