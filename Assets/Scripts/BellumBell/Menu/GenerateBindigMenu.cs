using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Samples.RebindUI;
using UnityEngine.UI;

public class GenerateBindigMenu : MonoBehaviour
{
    [SerializeField] private GameObject bindPrefab, startMapNameGO, test, rebindOverlay;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Text messageText, rebindText;
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] bool showCompositeByParts;

    private InputActionMap testingMap;
    private Transform newBindingButtonTransform;
    private RebindActionUI newRAUI;
    private InputActionReference actionReference;

    private Vector3 pos;

    void Awake()
    {
        var rOverlayTransform = rebindOverlay.transform;
        //var mapNameTransform = startMapNameGO.transform;

        for (int i = 0; i < actionAsset.actionMaps.Count; i++)
        {
            testingMap = actionAsset.actionMaps[i];
            if (testingMap.name.Contains("Pause"))
                continue;
            if (i == 0)
            {
                newBindingButtonTransform = startMapNameGO.transform; ;
                pos = newBindingButtonTransform.localPosition;
            }
            else
            {
                pos -= (Vector3.up * 60);
                newBindingButtonTransform = Instantiate(startMapNameGO, canvasTransform).transform;
                newBindingButtonTransform.localPosition = pos;
            }
            newBindingButtonTransform.GetChild(0).GetComponent<Text>().text = testingMap.name;

            foreach (var item in testingMap.actions)
            {
                if (item.name.Contains("Pause"))
                    continue;
                foreach (var bind in item.bindings)
                {
                    if ((showCompositeByParts ? bind.isComposite : bind.isPartOfComposite) || bind.ToString().Contains("Gamepad"))
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
