using UnityEngine;
using UnityEngine.UI;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] float _timeRecharge;

    bool isActive = true;

    public virtual void Init() { }

    public void Activate()
    {
        if (isActive == false)
            return;

        isActive = false;
        OnClick();
        Invoke("BaseRecharge", _timeRecharge);
    }

    void BaseRecharge()
    {
        isActive = true;
    }

    protected virtual void OnClick() { } 
}
