using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Weapon _weapon;

    public static Target Instance;

    private void Start()
    {
        Instance = this;
    }

    public Vector3 GetPosition()
    {
        var pos = transform.position;// * _camera.farClipPlane;
        pos.z = -10;

        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        var vec = GetMouseWorldPosition();

        transform.position = vec;

        if (Input.GetMouseButtonDown(0) && CheckIsInRightPlace())
        {
            _weapon.Shoot();
        }
    }

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
}
