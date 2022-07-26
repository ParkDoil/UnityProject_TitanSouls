using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public float Speed;
    public GameObject WeakPoint;
    public ParticleSystem HitEffect;

    Rigidbody2D _rigid;
    Animator _animator;

    private bool IsLeft;
    private bool IsDead;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _rigid.velocity = Vector2.zero;

        if (WeakPoint.GetComponent<WeakPoint>().IsHit == true)
        {
            IsDead = true;

            _animator.SetTrigger(BossAnimID.DIE);

            //HitEffect.transform.position = WeakPoint.transform.position;
            //HitEffect.transform.rotation = WeakPoint.transform.rotation;
            //HitEffect.Play();

            Invoke("Die", 1.5f);
        }

        if (IsDead == false)
        {
             Move();
        }
    }

    void Move()
    {
        Vector2 MoveVec = Vector2.right * Speed;
        if (IsLeft == true)
        {
            _rigid.AddForce(-MoveVec);

            if (transform.position.x <= -16f)
            {
                IsLeft = false;
            }
        }
        else
        {
            _rigid.AddForce(MoveVec);

            if(transform.position.x >= 7f)
            {
                IsLeft = true;
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
