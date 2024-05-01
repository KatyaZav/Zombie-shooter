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
        var mouse = Input.mousePosition;
        mouse.z = _camera.nearClipPlane;
        var vec = _camera.ScreenToWorldPoint(mouse);
        //vec.z = -5f;
        transform.position = vec;

        if (Input.GetMouseButtonDown(0))
        {
            _weapon.Shoot();
        }
    }
}
