using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2WeakPoint : MonoBehaviour
{

    public bool IsHit { get; private set; }

    void Start()
    {
        IsHit = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            IsHit = true;
        }
    }
}
