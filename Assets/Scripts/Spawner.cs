using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<BaseZombie> _zombies = new List<BaseZombie>();
    [SerializeField] Transform _left, _right, _bigSpawnZone, _smallSpawnZone;
    [SerializeField] GameObject _zombiePrefab;

    [Range(1, 20), SerializeField] float _timeInSpawn; 

    ObjectPool<BaseZombie> _zombiesPool;

    public void StopAllZombies(bool isTrue)
    {
        foreach (var e in _zombies)
            e.MakeStop(isTrue);
    }

    public void PoisonAllZombies(float damage, float longTime, float perTime = 1f)
    {
        StartCoroutine(PoisonEffect(damage, longTime, perTime));
    }

    public void Init()
    {
        StartCoroutine(SpawnInTime());
        _zombiesPool = new ObjectPool<BaseZombie>(_zombiePrefab);

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

            var zombie = _zombiesPool.GetObject(this.transform);
            Vector3 vector = new Vector3(GenerateRandomXPosition(), 0, 0);
            zombie.Init(vector);

            _zombies.Add(zombie);            
        }
    }

    void RemoveZombie(int i, BaseZombie zombie)
    {
        _zombiesPool.ReturnObject(zombie);
        _zombies.Remove(zombie);
    }

    private float GenerateRandomXPosition()
    {
        return Random.Range(_left.localPosition.x, _right.localPosition.x);
    }

    private IEnumerator PoisonEffect(float damage, float longTime, float perTime = 1f)
    {
        var a = 0f;
        while (a <= longTime)
        {
            yield return new WaitForSeconds(perTime);
            a += perTime;

            foreach (var e in _zombies)
            {
                e.Poison(damage);
            }
        }
    }
}
