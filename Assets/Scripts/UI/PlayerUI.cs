using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Animator _anim;

    public void Init(float hp)
    {
        _text.text = hp.ToString();
    }

    public void AddPoint(float hp)
    {
        _anim.SetTrigger("add");
        _text.text = hp.ToString();
    }

    public void RemovePoint(float hp)
    {
        _anim.SetTrigger("remove");
        _text.text = hp.ToString();
    }

}
