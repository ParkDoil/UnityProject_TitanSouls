using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    PlayerInput _input;

    void Start()
    {
        _input = GetComponentInParent<PlayerInput>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(_input.Y, _input.X) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
