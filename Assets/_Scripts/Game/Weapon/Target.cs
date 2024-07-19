using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target Instance;

    [SerializeField] Camera _camera;
    [SerializeField] Weapon _weapon;
    [SerializeField] Animator _anim;

    [Space(20)]
    [Header("Sounds")]
    [SerializeField] AudioComponent _audio;
    [SerializeField] AudioClip _onShootAudio, _onCantShootAudio, _onUnLimited;

    public bool CheackCanShoot()
    {
        return _weapon.CheckCanShoot();
    }

    public void MakeUnLimited(bool isUn)
    {
        _weapon.MakeUnlimited(isUn);

        if (isUn)
            _audio.MakeSound(_onUnLimited, true);
        else
            _audio.Stop();        
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
        _audio.TryInit();
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
        _audio.MakeSound(_onShootAudio);
        _anim.SetTrigger("shoot");
    }

    private void OnCantShoot()
    {
        _audio.MakeSound(_onCantShootAudio);
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
