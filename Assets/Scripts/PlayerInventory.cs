using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textHP;
    [SerializeField] TextMeshProUGUI _textPoints;

    private int _hp;
    private int _points;

    private static int _damage = 10;
    public static int Damage { get => _damage; }

    public void Init()
    {
        UpdateHealth();
        UpdatePoints();

        BaseZombie.ZombieKilledEvent += AddPoints;
    }

    public void Hit(int hp)
    {
        _hp -= hp;
        UpdateHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        var zombie = other.gameObject.GetComponentInParent<BaseZombie>();
        Debug.Log(zombie);

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
        UpdatePoints();
    }

    private void UpdateHealth()
    {
        _textHP.text = _hp.ToString();
    }
    private void UpdatePoints()
    {
        _textPoints.text = _points.ToString();
    }
}
