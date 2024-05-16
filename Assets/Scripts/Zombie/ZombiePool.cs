using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePool : MonoBehaviour
{
    [SerializeField] Queue<BaseZombie> _zombies = new Queue<BaseZombie>();
    [SerializeField] GameObject _zombiePrefab;

    public BaseZombie GetZombie()
    {
        BaseZombie zombie;
        Debug.Log(_zombies.Count);

        if (_zombies.TryDequeue(out zombie))
        {
            Debug.Log("Get");
            return zombie;
        }
        else
        {
            Debug.Log("Spawn");
            return Instantiate(_zombiePrefab, transform).GetComponent<BaseZombie>();
        }
    }

    public void ReturnZombie(BaseZombie zombie)
    {
        Debug.Log("return");
        _zombies.Enqueue(zombie);
    }
}
