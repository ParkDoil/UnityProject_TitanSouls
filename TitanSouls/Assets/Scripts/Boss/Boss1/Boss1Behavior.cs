using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public float Speed;
    public Sprite DieSprites;
    public GameObject WeakPoint;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigid;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (WeakPoint.GetComponent<WeakPoint>().IsHit)
        {
            _spriteRenderer.sprite = DieSprites;

            Invoke("Die", 1f);
        }
    }

    void Die()
    {
        gameObject.SetActive(false);

    }

}
