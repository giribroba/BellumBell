using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Samples.RebindUI;
using UnityEngine.UI;

public class GenerateBindigMenu : MonoBehaviour
{
    [SerializeField] private GameObject bindPrefab, startMapNameGO, canvas;
    [SerializeField] private InputActionAsset actionAsset;

    private Vector3 pos;
    void Start()
    {
        InputActionMap testingMap;
        Transform newBindingButton;
        RebindActionUI newRAUI;

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

                    newBindingButton = Instantiate(bindPrefab).transform;
                    newBindingButton.SetParent(canvas.transform);
                    newBindingButton.localPosition = pos;
                    newBindingButton.localScale = bindPrefab.transform.localScale;

                    newRAUI = newBindingButton.GetComponent<RebindActionUI>();
                    //newRAUI.inputAction = item;
                    //print(newRAUI.inputAction);
                }
            }

        }
    }
}
