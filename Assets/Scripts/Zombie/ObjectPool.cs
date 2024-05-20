using System.Collections;
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
        //Debug.Log(_zombies.Count);

        if (_zombies.TryDequeue(out zombie))
        {
            //Debug.Log("Get");
            return zombie;
        }
        else
        {
            //Debug.Log("Spawn");
            return GameObject.Instantiate(_objectPrefab, transform).GetComponent<T>();
        }
    }

    public void ReturnObject(T zombie)
    {
        //Debug.Log("return");

        //Debug.Log("Before adding zombie" + _zombies.Count);
        _zombies.Enqueue(zombie);
        //Debug.Log("After adding zombie" + _zombies.Count);
    }
}
