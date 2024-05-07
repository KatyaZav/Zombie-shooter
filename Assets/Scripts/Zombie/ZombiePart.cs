using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Destroy  bulet");
            Destroy(other.gameObject);
        }        
    }
}
