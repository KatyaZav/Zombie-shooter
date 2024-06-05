using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TranslationText
{
    [SerializeField] string _rus;
    [SerializeField] string _en;
    [SerializeField] string _tur;

    public string GetText(string language)
    {
        if (language == "ru")
            return _rus;

        if (language == "en")
            return _en;

        if (language == "tr")
            return _tur;

        return "error";
    }
}
