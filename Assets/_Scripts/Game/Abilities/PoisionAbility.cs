using UnityEngine;

public class PoisionAbility : BaseAbility
{
    [SerializeField] Spawner _spawner;
    [SerializeField] PlayerInventory _inv;
    [SerializeField] float _damage;

    protected override void OnClick()
    {
        //if (Random.Range(0, 10) <= 1)
        //    _inv.Hit(1);

        _spawner.PoisonAllZombies(_damage, _timeActive);
        base.OnClick();
    }
}
