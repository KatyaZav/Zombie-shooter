
public class Pistol : Weapon
{
    protected override void OnAttack()
    {
        var pos = Target.Instance.GetPosition();

        Instantiate(_cartridge, pos, _cartridge.transform.rotation);
    }
}
