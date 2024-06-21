using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public static int Damage { get => _damage; }

    [SerializeField] LoseMenu Lose;
    [SerializeField] PlayerUI _healthUI;
    [SerializeField] PlayerUI _pointsUI;
    [SerializeField] Spawner _spawner;

    [SerializeField] TextMeshProUGUI _textPoints;
    [SerializeField] int[] _damageUpd;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _loseAudio, _pointAudio, _hitAudio, _addHpAudio;

    private int _hp;
    private int _points;

    private static int _damage;

    public void Init()
    {
        _damage = _damageUpd[YG.YandexGame.savesData.Pistol[(int)WeaponSettings.power]];

        _healthUI.Init(_hp);
        _pointsUI.Init(_points);

        BaseZombie.ZombieKilledEvent += AddPoints;
    }

    public void Hit(int hp)
    {
        _hp -= hp;
        _audio.MakeSound(_hitAudio);

        if (_hp < 0)
        {
            _audio.MakeSound(_loseAudio);
            float a, b;
            PlayerSave.GetMinAndMax(out a, out b);

            int money = Mathf.RoundToInt(_points * Random.Range(a, b));
            Debug.Log("Getted money " + money);
            PlayerSave.AddMoney(money);
            PlayerSave.SetRecord(_points);

            PlayerSave.AddGameCount();
            Lose.SetMoney(money);
            Lose.gameObject.SetActive(true);
        }

        _healthUI.RemovePoint(_hp);
    }

    public void AddHealth(int hp)
    {
        _hp += hp;
        _healthUI.AddPoint(_hp);
        _audio.MakeSound(_addHpAudio);
    }

    private void OnTriggerEnter(Collider other)
    {
        var zombie = other.gameObject.GetComponentInParent<BaseZombie>();
        //Debug.Log(zombie);

        if (zombie != null)
        {
            zombie.Attack(this);
        }
    }

    private void OnDisable()
    {
        BaseZombie.ZombieKilledEvent -= AddPoints;        
    }

    private void AddPoints(int po, BaseZombie zombie)
    {
        _points += po;
        _pointsUI.AddPoint(_points);
        _spawner.AddPoints(_points);
        _audio.MakeSound(_pointAudio);
    }
}
