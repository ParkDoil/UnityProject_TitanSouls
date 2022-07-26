using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public float Speed;
    public Sprite Sprites;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigid;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
    }

}
