using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1WeakPoint : MonoBehaviour
{
    Boss1Behavior _script;

    public bool IsHit { get; private set; }
    void Start()
    {
        IsHit = false;
        _script = GetComponentInParent<Boss1Behavior>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow" && _script.IsShootArc == false)
        {
            IsHit = true;
        }
    }
}
