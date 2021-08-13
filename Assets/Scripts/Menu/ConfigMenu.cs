using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    GameObject[] sensi;
    Scrollbar xBar, yBar;
    float _xAxisCamSensi, _yAxisCamSensi;
    string file;
    static ControllerBinds crrntBinds;

    public ControllerBinds CrrntBinds
    {
        get => crrntBinds;
    }

    void Awake()
    {
        file = Application.persistentDataPath + "/Save/Config.json";
        if (!File.Exists(file))
        {
            Redefine();
        }
        else
        {
            crrntBinds = JsonConvert.DeserializeObject<ControllerBinds>(File.ReadAllText(file));
        }

        UpdateButtons();
    }

    public void LoadScene(string target)
    {
        SceneManager.LoadScene(target);
    }
    public void Redefine()
    {
        crrntBinds = new ControllerBinds();
        Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
        File.Create(file).Close();
        File.WriteAllText(file, crrntBinds.ToJson());
        UpdateButtons();
        Save();
    }
    public void UpdateButtons()
    {
        sensi = GameObject.FindGameObjectsWithTag("Sensi");

        xBar = sensi[0].transform.GetComponent<Scrollbar>();
        yBar = sensi[1].transform.GetComponent<Scrollbar>();

        xBar.onValueChanged.RemoveAllListeners();
        yBar.onValueChanged.RemoveAllListeners();

        xBar.value = crrntBinds.XAxisCamSensi / 3;
        yBar.value = crrntBinds.YAxisCamSensi / 3;

        sensi[0].transform.GetChild(1).GetComponent<Text>().text = (xBar.value * 3).ToString("n3");
        sensi[1].transform.GetChild(1).GetComponent<Text>().text = (yBar.value * 3).ToString("n3");

        UpdateScrollStringValue(xBar.value, sensi[0].transform.GetChild(1).GetComponent<Text>());
        UpdateScrollStringValue(yBar.value, sensi[1].transform.GetChild(1).GetComponent<Text>());

        yBar.onValueChanged.AddListener((float val) => UpdateScrollStringValue(val, sensi[1].transform.GetChild(1).GetComponent<Text>()));
        xBar.onValueChanged.AddListener((float val) => UpdateScrollStringValue(val, sensi[0].transform.GetChild(1).GetComponent<Text>()));
    }
    public void UpdateScrollStringValue(float value, Text text)
    {
        text.text = (value * 3).ToString("n3");

        crrntBinds.XAxisCamSensi = xBar.value * 3;
        crrntBinds.YAxisCamSensi = yBar.value * 3;

        this.Save();
    }

    public void Save()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
        File.Create(file).Close();
        File.WriteAllText(file, crrntBinds.ToJson());
    }
}
