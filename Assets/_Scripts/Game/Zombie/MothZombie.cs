using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothZombie : BaseZombie
{
    PlayerInventory _inventory;
    //[SerializeField] Sprite _sprite;

    public void Init(Vector3 pos, PlayerInventory inventory)
    {
        base.Init(pos);
        _inventory = inventory;
    }

    public override void Attack(PlayerInventory inventory)
    {
        inventory.Hit(1);
        Destroy(gameObject);
    }

    protected override void OnDead()
    {
        _inventory.AddHealth(1);
        base.OnDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Instantiate(_sprite, other.transform.position, Quaternion.identity);
            //Debug.Log("Destroy  bulet");
            Destroy(other.gameObject);
            RemoveHp(1);
        }
    }
}
