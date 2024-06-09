using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMenu : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Animator _anim;

    void Update()
    {
        var vec = GetMouseWorldPosition();
        transform.position = vec;

        if (Input.GetMouseButtonDown(0))
            OnShoot();
    }

    void OnShoot()
    {
        _anim.SetTrigger("shoot");

    }

    Vector3 GetMouseWorldPosition()
    {
        var mouse = Input.mousePosition;
        mouse.z = _camera.nearClipPlane;
        return _camera.ScreenToWorldPoint(mouse);
    }
}
