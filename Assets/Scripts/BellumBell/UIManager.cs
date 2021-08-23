using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject configMenu;
    [SerializeField] GameObject mobileHud;
    [SerializeField] AnimationCurve menuAnimSizeCurve;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    [SerializeField] CharacterBehaviour player;
    [SerializeField] Joystick joyPlayer, joyCamera;

    float menuAnimCurrentTime;
    Coroutine lastCoroutine;
    ControllerBinds cBinds;
    CinemachinePOV POV;

    void Awake()
    {
        POV = cinemachine.AddCinemachineComponent<CinemachinePOV>();
        POV.m_HorizontalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;
        POV.m_VerticalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;

#if UNITY_STANDALONE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#elif UNITY_ANDROID
        mobileHud.setActive(true);
        POV.m_HorizontalAxis.m_InputAxisName = "";
        POV.m_VerticalAxis.m_InputAxisName = "";

        joyPlayer = GameObject.Find("JoystickPlayer").GetComponent<Joystick>();
        joyCamera = GameObject.Find("JoystickCamera").GetComponent<Joystick>();
#endif
    }

    void Start()
    {
        cBinds = configMenu.GetComponent<ConfigMenu>().CrrntBinds;
        configMenu.transform.localScale = Vector3.zero;
        POV.m_HorizontalAxis.m_MaxSpeed = cBinds.XAxisCamSensi;
        POV.m_VerticalAxis.m_MaxSpeed = cBinds.YAxisCamSensi;
    }

    void Update()
    {  
        MoveInputs();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void MoveInputs()
    {
#if UNITY_STANDALONE
        player.Vertical = cBinds.Axis(player.Vertical, cBinds.GetKey("Forward"), cBinds.GetKey("Backward")); //Similar of Input.GetAxis("Vertical")
        player.Horizontal = cBinds.Axis(player.Horizontal, cBinds.GetKey("Right"), cBinds.GetKey("Left"));  // Similar of Input.GetAxis("Horizontal")
        player.Running = Input.GetKey(cBinds.GetKey("Run"));
#elif UNITY_ANDROID
        player.Vertical = joyPlayer.Vertical * 6;
        player.Horizontal = joyPlayer.Horizontal * 6;
#endif
    }

    public void Pause()
    {
        if(lastCoroutine != null)
            StopCoroutine(lastCoroutine);

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            POV.m_HorizontalAxis.m_MaxSpeed = 0;
            POV.m_VerticalAxis.m_MaxSpeed = 0;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            cBinds = configMenu.GetComponent<ConfigMenu>().CrrntBinds;
            configMenu.GetComponent<ConfigMenu>().Save();
            Time.timeScale = 1;
            POV.m_HorizontalAxis.m_MaxSpeed = cBinds.XAxisCamSensi;
            POV.m_VerticalAxis.m_MaxSpeed = cBinds.YAxisCamSensi;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        lastCoroutine = StartCoroutine(AnimMenuSize(configMenu, 1, Time.timeScale != 0));
    }

    private IEnumerator AnimMenuSize(GameObject menu, float time, bool isOpen)
    {
        if (!isOpen)
        {
            while (menuAnimCurrentTime < time)
            {
                menu.transform.localScale = Vector3.one * menuAnimSizeCurve.Evaluate(menuAnimCurrentTime / time);
                menuAnimCurrentTime += Time.fixedDeltaTime;
                yield return null;
            }
        }
        else
        {
            while (menuAnimCurrentTime > 0)
            {
                menu.transform.localScale = Vector3.one * menuAnimSizeCurve.Evaluate(menuAnimCurrentTime / time);
                menuAnimCurrentTime -= Time.fixedDeltaTime;
                yield return null;
            }
        }
    }

    public void InteractionButton_A()
    {
        print("pei pou");
    }
    public void InteractionButton_B()
    {
        print("POOOOOOOOOUW");
    }
}
