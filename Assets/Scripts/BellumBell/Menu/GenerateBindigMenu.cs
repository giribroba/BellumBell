using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Samples.RebindUI;
using UnityEngine.UI;

public class GenerateBindigMenu : MonoBehaviour
{
    [SerializeField] private GameObject bindPrefab, startMapNameGO, test, rebindOverlay;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Text messageText, rebindText;
    [SerializeField] private InputActionAsset actionAsset;

    private InputActionMap testingMap;
    private Transform newBindingButtonTransform;
    private RebindActionUI newRAUI;
    private InputActionReference actionReference;

    private Vector3 pos;

    void Awake()
    {
        var rOverlayTransform = rebindOverlay.transform;

        for (int i = 0; i < actionAsset.actionMaps.Count; i++)
        {
            testingMap = actionAsset.actionMaps[i];
            if (testingMap.name.Contains("Pause"))
                continue;
            if (i == 0)
            {
                pos = startMapNameGO.transform.localPosition;
                startMapNameGO.transform.GetChild(0).GetComponent<Text>().text = testingMap.name;
            }

            foreach (var item in testingMap.actions)
            {
                if (item.name.Contains("Pause"))
                    continue;
                foreach (var bind in item.bindings)
                {
                    if (bind.isPartOfComposite || bind.ToString().Contains("Gamepad"))
                        continue;

                    pos -= (Vector3.up * 60);

                    newBindingButtonTransform = Instantiate(bindPrefab, canvasTransform).transform;
                    newBindingButtonTransform.localPosition = pos;

                    actionReference = ScriptableObject.CreateInstance(typeof(InputActionReference)) as InputActionReference;
                    actionReference.Set(actionAsset, testingMap.name, bind.action);

                    newRAUI = newBindingButtonTransform.GetComponent<RebindActionUI>();
                    newRAUI.Init(actionReference, bind.id.ToString(), messageText, rebindText, rebindOverlay);
                }
            }
        }
        rebindOverlay.transform.SetAsLastSibling();
    }
}
