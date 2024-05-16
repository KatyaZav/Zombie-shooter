using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<BaseZombie> _zombies;
    [SerializeField] Transform _left, _right, _bigSpawnZone, _smallSpawnZone;
    [SerializeField] ZombiePool _zombiesPool;

    [Range(1, 20), SerializeField] float _timeInSpawn; 


    public void Init()
    {
        StartCoroutine(SpawnInTime());

        BaseZombie.ZombieKilledEvent += RemoveZombie;
    }

    private void OnDisable()
    {
        BaseZombie.ZombieKilledEvent -= RemoveZombie;        
    }

    private IEnumerator SpawnInTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeInSpawn);

            var zombie = _zombiesPool.GetZombie();
            Vector3 vector = new Vector3(GenerateRandomXPosition(), 0, 0);
            zombie.Init(vector);

            _zombies.Add(zombie);            
        }
    }

    void RemoveZombie(int i, BaseZombie zombie)
    {
        _zombiesPool.ReturnZombie(zombie);
        _zombies.Remove(zombie);
    }

    private float GenerateRandomXPosition()
    {
        return Random.Range(_left.localPosition.x, _right.localPosition.x);
    }
}
