using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject configMenu;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    [SerializeField] CharacterBehaviour player;
    [SerializeField] Joystick joyPlayer, joyCamera;
    [SerializeField] UIManager uiManager;

    public static PlayerInputActions inputActions;
    ControllerBinds cBinds;
    public static CinemachinePOV POV;

    private void Awake()
    {
        POV = cinemachine.AddCinemachineComponent<CinemachinePOV>();
        POV.m_HorizontalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;
        POV.m_VerticalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;

        inputActions = new PlayerInputActions();
        SetInputs();
        inputActions.Walking.Enable();

#if UNITY_ANDROID              
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
    }

    public void SetInputs()
    {
        inputActions.Walking.Pause.started += uiManager.Pause;
        inputActions.Paused.Close.started += uiManager.Pause;
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
}
