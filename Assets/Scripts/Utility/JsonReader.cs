using System;
using System.Collections.Generic;
using UnityEngine;


public class JsonReader:MonoBehaviour
{
    public static TranslatedTexts TranslateTo(string Language)
    {
        TextAsset jsonInfo = Resources.Load<TextAsset>("i18n/" + Language);
        TranslatedTexts lenguageReader = JsonUtility.FromJson<TranslatedTexts>(jsonInfo.text);
        return lenguageReader;
    }
    void Start()
    {
        //examples
        print(JsonReader.TranslateTo("eng").cards[1].description);
        print(JsonReader.TranslateTo("pt-br").cards[1].description);
    }
#region serialization

    [Serializable]
    public class TranslatedTexts
    {
        public Card[] cards;
        public MenuInfo[] menuInfo;
    }
    [Serializable]
    public class MenuInfo
    {
        public string initialButton;
        public string description;
    }
    [Serializable]
    public class Card
    {
        public string name;
        public string description;
    }
    
#endregion

}
