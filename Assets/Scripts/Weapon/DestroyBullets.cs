using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject, 0.1f);
        }        
    }
}
