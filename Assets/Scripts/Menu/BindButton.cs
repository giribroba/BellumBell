using UnityEngine.UI;
using UnityEngine;

public class BindButton : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] ConfigMenu config;
    [SerializeField] string thisName;

    GameObject[] buttonBinds; 

    [HideInInspector] public bool choosing;

    private void Start()
    {
        choosing = false;
        buttonBinds = GameObject.FindGameObjectsWithTag("BtnBind");
    }
    void Update()
    {
        if (choosing)
        {
            text.text = "...";
        }
        else
        {
            text.text = config.CrrntBinds.GetKey(thisName).ToString();
        }
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && choosing)
        {
            config.CrrntBinds.SetBindValue(thisName, e.keyCode);
            config.Save();
            choosing = false;
        }
    }
    public void Choose()
    {
        foreach (var i in buttonBinds)
            i.GetComponent<BindButton>().choosing = false;

        choosing = true;
    }
}
