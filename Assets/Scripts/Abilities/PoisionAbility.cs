using UnityEngine;

public class PoisionAbility : BaseAbility
{
    [SerializeField] Spawner _spawner;
    [SerializeField] float _damage;

    protected override void OnClick()
    {
        _spawner.PoisonAllZombies(_damage, _timeActive);
        base.OnClick();
    }
}
