using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Animator _animator;
    public float X { get; private set; }
    public float Y { get; private set; }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        X = Y = 0f;
        X = Input.GetAxis("Horizontal");
        _animator.SetFloat("ValueX", X);
        Y = Input.GetAxis("Vertical");
        _animator.SetFloat("ValueY", Y);
    }
}
