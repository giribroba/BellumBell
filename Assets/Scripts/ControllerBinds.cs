using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBinds
{
    //movement
    [JsonProperty]
    Dictionary<string, KeyCode> binds = new Dictionary<string, KeyCode>
    {
        {"Forward", KeyCode.W},
        {"Backward", KeyCode.S},
        {"Right", KeyCode.D},
        {"Left", KeyCode.A},
        {"Run", KeyCode.LeftShift}
    };
    const float acceleration = 0.1f;

    //camera
    private float xAxisCamSensi = 1, yAxisCamSensi = 1;

    public float XAxisCamSensi
    {
        get => xAxisCamSensi;
        set { xAxisCamSensi = value; }
    }
    public float YAxisCamSensi
    {
        get => yAxisCamSensi;
        set { yAxisCamSensi = value; }
    }

    public float Axis(float axis, KeyCode positive, KeyCode negative)
    {
        if (Input.GetKey(positive) | Input.GetKey(negative))
        {
            if (Input.GetKey(positive))
            {
                axis += acceleration;
                if (axis > 1)
                {
                    axis = 1;
                }
            }
            if (Input.GetKey(negative))
            {
                axis -= acceleration;
                if (axis < -1)
                {
                    axis = -1;
                }
            }
        }
        else
        {
            axis += (axis != 0 ? (axis < 0 ? acceleration : -acceleration) : 0);
            axis = (Mathf.Abs(axis) < acceleration ? 0 : axis);
        }

        return axis;
    }
    public KeyCode GetKey(string keyName)
    {
        return this.binds[keyName];
    }
    public int GetBindsSize()
    {
        return this.binds.Count;
    }
    public KeyCode[] BindsValuesArray()
    {
        var result = new KeyCode[this.GetBindsSize()];
        this.binds.Values.CopyTo(result, 0);
        return result;
    }
    public void SetBindValue(string bindName, KeyCode newValue)
    {
        this.binds[bindName] = newValue;
    }
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}

