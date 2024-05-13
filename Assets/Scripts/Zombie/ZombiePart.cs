using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePart : MonoBehaviour
{
    public Action<float> DamagePartEvent;

    [SerializeField] int _damageCoefficient = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Destroy  bulet");
            Destroy(other.gameObject);

            DamagePartEvent?.Invoke(_damageCoefficient);
        }        
    }
}
