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

    [Range(1.5f, 4), SerializeField] float _timeInSpawn;
    [SerializeField] float _maxScore;

    ObjectPool<BaseZombie> _zombiesPool;
    bool wasInit;

    float min = 1.5f;
    float max = 4;

    public void AddPoints(int point)
    {
        if (point == 0)
        {
            _timeInSpawn = 8;
            return;
        }

        float A = min - max;
        float B = 1 - _maxScore;
        float C = _maxScore * max - min;

        float k = -A / B;
        float b = -C / B;

        _timeInSpawn = (k*point) + b;
    }

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
        if (PlayerSave.GameCount < 2)
            max = 4;
        else if (PlayerSave.GameCount < 8)
            max = 3.5f;
        else if (PlayerSave.GameCount < 15)
            max = 3.2f;
        else if (PlayerSave.GameCount < 20)
            max = 3;

        _zombiesPool = new ObjectPool<BaseZombie>(_zombiePrefab);
        StartCoroutine(SpawnInTime(true));

        BaseZombie.ZombieKilledEvent += RemoveZombie;
        wasInit = true;
    }

    private void OnDisable()
    {
        BaseZombie.ZombieKilledEvent -= RemoveZombie;
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        if (wasInit == false)
            return;

        BaseZombie.ZombieKilledEvent += RemoveZombie;
        StartCoroutine(SpawnInTime(false));
    }

    private IEnumerator SpawnInTime(bool needFirst)
    {
        if (needFirst)
            _zombies.Add(ChooseZombie());     
        
        while (true)
        {


            yield return new WaitForSeconds(_timeInSpawn);
            _zombies.Add(ChooseZombie());            
        }
    }

    private BaseZombie ChooseZombie()
    {
        Vector3 vector = new Vector3(GenerateRandomXPosition(), 0, 0);

        BaseZombie zombie;

        if (Random.Range(0f,8f) <= 0.6f)
        {
            var zombie1 = Instantiate(_flyPrefab, transform);
            zombie1.transform.localPosition = vector;
            var zombieMoth = zombie1.GetComponent<MothZombie>();
            zombieMoth.Init(vector, _inventory);

            zombie = zombieMoth;
        }
        else
        {
            zombie = _zombiesPool.GetObject(this.transform);
            zombie.Init(vector);
        }


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
