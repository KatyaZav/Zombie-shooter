using UnityEngine;

public class Sword : BaseItems
{
    protected override void OnInit() 
    {
        _zombie.AddDamage();
    }

    protected override void OnDestroyd()
    {
        _zombie.AddDamage(-1);
        gameObject.SetActive(false);
    }
}
