using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject configMenu;
    [SerializeField] GameObject mobileHud;
    [SerializeField] AnimationCurve menuAnimSizeCurve;
    [SerializeField] CinemachineVirtualCamera virtualCam;

    float menuAnimCurrentTime;
    Coroutine lastCoroutine;
    ControllerBinds cBinds;

    void Awake()
    {
#if UNITY_STANDALONE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#elif UNITY_ANDROID
        mobileHud.setActive(true);
#endif
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (lastCoroutine != null)
            StopCoroutine(lastCoroutine);

        //Pause
        if (Time.timeScale != 0)
        {
            InputManager.inputActions.Walking.Disable();
            InputManager.inputActions.Paused.Enable();

            Time.timeScale = 0;
            virtualCam.enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        //Unpause
        else
        {
            InputManager.inputActions.Walking.Enable();
            InputManager.inputActions.Paused.Disable();

            cBinds = configMenu.GetComponent<ConfigMenu>().CrrntBinds;
            configMenu.GetComponent<ConfigMenu>().Save();
            Time.timeScale = 1;
            virtualCam.enabled = true;

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
}
