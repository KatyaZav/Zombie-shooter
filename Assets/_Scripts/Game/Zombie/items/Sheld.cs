using UnityEngine;

public class Sheld : BaseItems
{
    protected override void OnInit()
    {
        _zombie.ChangeSpeed(30);
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
        _zombie.ChangeSpeed(130);
        gameObject.SetActive(false);
    }
}
