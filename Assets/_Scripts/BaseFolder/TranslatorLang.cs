using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatorLang : MonoBehaviour
{
    [SerializeField] string _rus = "error";
    [SerializeField] string _eng = "error";
    [SerializeField] string _tur = "error";

    public string GetText(string lang)
    {
        switch (lang)
        {
            case "ru":
                return _rus;
            case "en":
                return _eng;
            case "tr":
                return _tur;
            default:
                return "error";
        }
    }
}
