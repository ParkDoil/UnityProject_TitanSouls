using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    private float _angle;
    Vector2 _target, _mouse;

    private void Start()
    {
        _target = transform.position;
    }
    private void Update()
    {
        _mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _angle = Mathf.Atan2(_mouse.y - _target.y, _mouse.x - _target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle - 90, Vector3.forward);
    }
}
