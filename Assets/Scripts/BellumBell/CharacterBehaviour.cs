using Cinemachine;
using System.Collections;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] CharacterController controll;
    [SerializeField] Canvas canvas;
    [SerializeField] float normalSpeed, suavityTime, rotationSpeed;
    [SerializeField] GameObject panel;
    [SerializeField] AnimationCurve speedCurve;

    ControllerBinds cBinds;
    public ControllerBinds CBinds { get { return cBinds;} set { cBinds = value;}}
    CinemachinePOV POV;
    public CinemachinePOV POView { get { return POV;} set {POV = value; }}

    Joystick joyPlayer, joyCamera;
    float vertical, horizontal, moveTime;
    Quaternion targetRotation;
    Vector3 movement;

    public delegate void PauseGame();
    public event PauseGame GamePaused;

    void Awake()
    {
#if UNITY_ANDROID
        joyPlayer = GameObject.Find("JoystickPlayer").GetComponent<Joystick>();
        joyCamera = GameObject.Find("JoystickCamera").GetComponent<Joystick>();
#endif
    }

    void Update()
    {
        Movimentation();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused();
        }
    }

    private void Movimentation()
    {
#if UNITY_STANDALONE
        vertical = cBinds.Axis(vertical, cBinds.GetKey("Forward"), cBinds.GetKey("Backward")); //Similar of Input.GetAxis("Vertical")
        horizontal = cBinds.Axis(horizontal, cBinds.GetKey("Right"), cBinds.GetKey("Left"));  // Similar of Input.GetAxis("Horizontal")
#elif UNITY_ANDROID
            vertical = joyPlayer.Vertical * 6;
            POV.m_HorizontalAxis.m_InputAxisValue = joyCamera.Horizontal;
            POV.m_VerticalAxis.m_InputAxisValue = joyCamera.Vertical;
            //cinemachine.m_XAxis.Value += joyCamera.Horizontal;
            horizontal = joyPlayer.Horizontal * 6;
#endif

        if (vertical != 0 || horizontal != 0)
        {
            var angleOffset = Mathf.Atan(horizontal / vertical) * 180 / Mathf.PI;
            targetRotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y + (float.IsNaN(angleOffset) ? 0 : angleOffset) + (vertical < 0 ? 180 : 0), 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Input.GetKey(cBinds.GetKey("Run")))
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

        transform.GetComponent<Animator>().SetFloat("Velocidade", controll.velocity.magnitude);

        movement += Physics.gravity / 20;

        controll.Move(movement);
    }

    public void InteractionButton_A()
    {
        print("pei pou");
    }
    public void InteractionButton_B()
    {
        print("POOOOOOOOOUW");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AreaTrigger")
        {
            //print("1");
            //OpenPanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AreaTrigger")
        {
            //print("2");
            //ClosePanel();
        }
    }

    // private IEnumerator OpenPanel()
    // {

    // }
    // private IEnumerator ClosePanel()
    // {

    // }
}
