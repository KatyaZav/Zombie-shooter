using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target Instance;

    [SerializeField] Camera _camera;
    [SerializeField] Weapon _weapon;
    [SerializeField] Animator _anim;

    public void MakeUnLimited(bool isUn)
    {
        _weapon.MakeUnlimited(isUn);
    }
    public Vector3 GetPosition()
    {
        var pos = transform.position;// * _camera.farClipPlane;
        pos.z = -10;

        return pos;
    }

    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        var vec = GetMouseWorldPosition();

        transform.position = vec;

        if (Input.GetMouseButtonDown(0) && CheckIsInRightPlace())
        {
            if (_weapon.Shoot())
                OnShoot();
            else
                OnCantShoot();
        }
    }

    #region OnShoot
    private void OnShoot()
    {
        _anim.SetTrigger("shoot");
    }

    private void OnCantShoot()
    {
        _anim.SetTrigger("not shoot");
    }
    #endregion

    #region Mouse
    Vector3 GetMouseWorldPosition()
    {
        var mouse = Input.mousePosition;
        mouse.z = _camera.nearClipPlane;
        return _camera.ScreenToWorldPoint(mouse);
    }

    bool CheckIsInRightPlace()
    {
        var vec = GetMouseWorldPosition();

        if (vec.y >= -3.2f && vec.y <= 3.5f)
            return true;
        else
            return false;
    }
    #endregion
}
