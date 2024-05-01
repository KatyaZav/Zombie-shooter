using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaledObject : MonoBehaviour
{
    void Update()
    {
        var vec = ContentScale.Instance.GetScale(transform);
        transform.localScale = new Vector3(vec, vec, 1);
    }
}
