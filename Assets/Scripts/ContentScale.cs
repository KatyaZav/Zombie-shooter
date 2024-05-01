using UnityEngine;

public class ContentScale : MonoBehaviour
{
    public static ContentScale Instance;

    [SerializeField] Transform _bg;
    [SerializeField] Transform _fg;

    [SerializeField] float minValue = 0.2f;
    [SerializeField] float maxValue = 2;

    public float GetScale(Transform obj)
    {
        var objPos = 1 - (_fg.position.z + obj.position.z)/(_bg.position.z+_fg.position.z);
        return objPos * (maxValue - minValue);
    }
    
    void Start()
    {
        Instance = this;
    }    
}
