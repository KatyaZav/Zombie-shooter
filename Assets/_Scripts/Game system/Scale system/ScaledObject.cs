using UnityEngine;

public class ScaledObject : MonoBehaviour
{
    float x, y;

    private void Awake()
    {
        x = transform.localScale.x;    
        y = transform.localScale.y;    
    }

    void Update()
    {
        var vec = ContentScale.Instance.GetScale(transform);
        transform.localScale = new Vector3(x*vec, y*vec, 1);
    }
}
