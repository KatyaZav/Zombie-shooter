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
        var ot = other.GetComponent<bullet>();

        if (ot != null)
        {
            if (ot.wasGetted == true)
                return;

            ot.wasGetted = true;
            //Debug.Log("Destroy  bulet");
            //nstantiate(_sprite, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            DamagePartEvent?.Invoke(_damageCoefficient * PlayerInventory.Damage);
        }        
    }
}
