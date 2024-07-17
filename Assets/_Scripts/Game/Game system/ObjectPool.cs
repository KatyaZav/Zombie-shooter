using System.Collections.Generic;
using UnityEngine;

public class ObjectPool <T>
{
    [SerializeField] Queue<T> _zombies = new Queue<T>();
    [SerializeField] GameObject _objectPrefab;

    public ObjectPool(GameObject prefab)
    {
        _objectPrefab = prefab;
    }

    public T GetObject(Transform transform)
    {
        T zombie;

        if (_zombies.TryDequeue(out zombie))
        {
            return zombie;
        }
        else
        {
            return GameObject.Instantiate(_objectPrefab, transform).GetComponent<T>();
        }
    }

    public void ReturnObject(T zombie)
    {
        _zombies.Enqueue(zombie);
    }
}
