using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public static int Damage { get => _damage; }

    [SerializeField] PlayerUI _healthUI;
    [SerializeField] PlayerUI _pointsUI;

    [SerializeField] TextMeshProUGUI _textPoints;

    private int _hp;
    private int _points;

    private static int _damage = 10;

    public void Init()
    {
        _healthUI.Init(_hp);
        _pointsUI.Init(_points);

        BaseZombie.ZombieKilledEvent += AddPoints;
    }

    public void Hit(int hp)
    {
        _hp -= hp;
        _healthUI.RemovePoint(_hp);
    }

    public void AddHealth(int hp)
    {
        _hp += hp;
        _healthUI.AddPoint(_hp);
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
    }
}
