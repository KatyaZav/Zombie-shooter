using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ZombiePart : MonoBehaviour, IDamageble
{
    public Action<float> DamagePartEvent;

    [SerializeField] int _damageCoefficient = 1;

    public void TakeDamage(float damage)
    {
        //PlayerInventory.Damage
        DamagePartEvent?.Invoke(_damageCoefficient * damage);
    }
}
