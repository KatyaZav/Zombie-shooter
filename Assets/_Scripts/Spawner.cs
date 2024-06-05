using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<BaseZombie> _zombies = new List<BaseZombie>();
    [SerializeField] Transform _left, _right;
    [SerializeField] GameObject _zombiePrefab;
    [SerializeField] GameObject _flyPrefab;
    [SerializeField] PlayerInventory _inventory;

    [Range(5, 15), SerializeField] float _timeInSpawn; 

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

            _zombies.Add(ChooseZombie());            

            yield return new WaitForSeconds(_timeInSpawn);
        }
    }

    private BaseZombie ChooseZombie()
    {
        Vector3 vector = new Vector3(GenerateRandomXPosition(), 0, 0);

        /*   var zombie = _zombiesPool.GetObject(this.transform);
           zombie.Init(vector);*/

        var zombie1 = Instantiate(_flyPrefab, transform);
        zombie1.transform.localPosition = vector;
        var zombie = zombie1.GetComponent<MothZombie>();
        zombie.Init(vector, _inventory);

        return zombie;
    }

    private void RemoveZombie(int i, BaseZombie zombie)
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
