using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ZombiePart : MonoBehaviour
{
    public Action<float> DamagePartEvent;

    //[SerializeField] Sprite _sprite;
    [SerializeField] int _damageCoefficient = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Destroy  bulet");
            //nstantiate(_sprite, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            DamagePartEvent?.Invoke(_damageCoefficient * PlayerInventory.Damage);
        }        
    }
}
