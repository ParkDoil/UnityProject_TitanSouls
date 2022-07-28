using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeftHand : Boss2HandBase
{
    NavMeshAgent _navMeshAgent;
    Behavior _script;
    SpriteRenderer _spriteRaderer;
    BoxCollider2D _boxCollider2D;

    public Sprite GoingSprite;
    public Sprite AttackSprite;
    public Sprite DefenseSprite;

    Vector3 _attackPosition;

    bool _hasPosition;
    float _elapsedTime;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _script = GetComponentInParent<Behavior>();
        _spriteRaderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;

        if (_script.IsDead == true)
        {
            _navMeshAgent.ResetPath();
        }
        else
        {
            if (_script.IsLeft == true)
            {
                if (_hasPosition == false)
                {
                    AttackPositionCheck();
                }

                Attack();
            }
            else
            {
                Defense();
            }
        }
    }
    public override void Attack()
    {
        _boxCollider2D.enabled = false;
        base.Attack();

        Vector3 dirvec = _attackPosition - transform.position;

        _spriteRaderer.sprite = GoingSprite;
        _navMeshAgent.speed = 30f;
        _navMeshAgent.acceleration = 60f;

        _navMeshAgent.SetDestination(_attackPosition);

        if (dirvec.sqrMagnitude <= 5f)
        {
            _boxCollider2D.enabled = true;
            _elapsedTime += Time.deltaTime;
            _spriteRaderer.sprite = AttackSprite;
        }

        if(_elapsedTime >= 2f)
        {
            _elapsedTime = 0f;
            _hasPosition = false;
        }
    }

    public override void Defense()
    {
        _navMeshAgent.ResetPath();
        _hasPosition = false;
        _boxCollider2D.enabled = true;

        base.Defense();
        _spriteRaderer.sprite = DefenseSprite;
        _navMeshAgent.speed = 15f;
        _navMeshAgent.acceleration = 30f;
        _navMeshAgent.SetDestination(_script.WeakPoint.transform.position);
    }

    void AttackPositionCheck()
    {
        _hasPosition = true;
        _attackPosition = _script.Player.transform.position;
    }
}
