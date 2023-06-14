using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject configMenu;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CharacterBehaviour player;
    [SerializeField] Joystick joyPlayer, joyCamera;
    [SerializeField] UIManager uiManager;

    public static PlayerInputActions inputActions;
    ControllerBinds cBinds;
    public static CinemachinePOV POV;

    private void Awake()
    {
        POV = virtualCamera.AddCinemachineComponent<CinemachinePOV>();
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
        inputActions.Walking.Run.started += SetRun;
        inputActions.Walking.Pause.started += uiManager.Pause;
        inputActions.Paused.Close.started += uiManager.Pause;
    }
    public void SetRun(InputAction.CallbackContext context) => player.Running = true;

    public void MoveInputs()
    {
#if UNITY_STANDALONE
        //player.Vertical = cBinds.Axis(player.Vertical, cBinds.GetKey("Forward"), cBinds.GetKey("Backward")); //Similar of Input.GetAxis("Vertical")
        //player.Horizontal = cBinds.Axis(player.Horizontal, cBinds.GetKey("Right"), cBinds.GetKey("Left"));  // Similar of Input.GetAxis("Horizontal")
        var walk = inputActions.Walking.Walk.ReadValue<Vector2>();
        player.Horizontal = walk.x;
        player.Vertical = walk.y;
        if(walk.magnitude <= 0.5f)
            player.Running = false;

        var cam = inputActions.Walking.Camera.ReadValue<Vector2>() * cBinds.XAxisCamSensi;
        POV.m_HorizontalAxis.Value += cam.x;
        POV.m_VerticalAxis.Value -= cam.y;
#elif UNITY_ANDROID
        //print(joyPlayer.Horizontal * 6);
        player.Vertical = joyPlayer.Vertical * 6;
        player.Horizontal = joyPlayer.Horizontal * 6;
#endif
    }
}
