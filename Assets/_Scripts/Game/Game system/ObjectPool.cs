using System.Collections.Generic;
using UnityEngine;

public class ObjectPool <T>
{
    private Queue<T> _zombies = new Queue<T>();
    private GameObject _objectPrefab;
    private int _maxCount;
    private int _currentCount;

    public ObjectPool(GameObject prefab, int maxCount)
    {
        _maxCount = maxCount;
        _objectPrefab = prefab;

        _currentCount = 0;
    }

    public bool CanGet() => _currentCount < _maxCount - 1;
    
    public T GetObject(Transform transform)
    {
        T zombie;
        //Debug.Log("Spawn " + _objectPrefab.name + " " + _currentCount);

        if (_zombies.TryDequeue(out zombie))
        {
            _currentCount++;
            return zombie;
        }
        else
        {
            _currentCount++;
            return GameObject.Instantiate(_objectPrefab, transform).GetComponent<T>();
        }
    }

    public void ReturnObject(T zombie)
    {
        _currentCount--;
        _zombies.Enqueue(zombie);
    }
}
