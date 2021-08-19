using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject configMenu;
    [SerializeField] GameObject mobileHud;
    [SerializeField] AnimationCurve menuAnimSizeCurve, panelAnimSizeCurve;
    [SerializeField] CinemachineVirtualCamera cinemachine;
    [SerializeField] CharacterBehaviour player;

    void Awake()
    {
        player.POView = cinemachine.AddCinemachineComponent<CinemachinePOV>();
        player.POView.m_HorizontalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;
        player.POView.m_VerticalAxis.m_SpeedMode = AxisState.SpeedMode.InputValueGain;

#if UNITY_STANDALONE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#elif UNITY_ANDROID
        mobileHud.setActive(true);
        player.POView.m_HorizontalAxis.m_InputAxisName = "";
        player.POView.m_VerticalAxis.m_InputAxisName = "";
#endif
    }

    void Start()
    {
        player.CBinds = configMenu.GetComponent<ConfigMenu>().CrrntBinds;
        configMenu.transform.localScale = Vector3.zero;
        player.POView.m_HorizontalAxis.m_MaxSpeed = player.CBinds.XAxisCamSensi;
        player.POView.m_VerticalAxis.m_MaxSpeed = player.CBinds.YAxisCamSensi;
    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            player.POView.m_HorizontalAxis.m_MaxSpeed = 0;
            player.POView.m_VerticalAxis.m_MaxSpeed = 0;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            StartCoroutine(AnimMenuSize(configMenu, 1, true));
        }
        else
        {
            player.CBinds = configMenu.GetComponent<ConfigMenu>().CrrntBinds;
            configMenu.GetComponent<ConfigMenu>().Save();
            Time.timeScale = 1;
            player.POView.m_HorizontalAxis.m_MaxSpeed = player.CBinds.XAxisCamSensi;
            player.POView.m_VerticalAxis.m_MaxSpeed = player.CBinds.YAxisCamSensi;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(AnimMenuSize(configMenu, 1, false));
        }
    }

    private IEnumerator AnimMenuSize(GameObject menu, float time, bool positive)
    {
        if (positive)
        {
            for (float i = 0; i < time; i += Time.fixedDeltaTime)
            {
                menu.transform.localScale = Vector3.one * menuAnimSizeCurve.Evaluate(i / time);
                yield return null;
            }
        }
        else
        {
            for (float i = time; i > 0; i -= Time.fixedDeltaTime)
            {
                menu.transform.localScale = Vector3.one * menuAnimSizeCurve.Evaluate(i / time);
                yield return null;
            }
        }
    }
}
