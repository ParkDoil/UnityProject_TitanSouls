using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightHand : Boss2HandBase
{
    NavMeshAgent _navMeshAgent;

    Behavior _script;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _script = GetComponentInParent<Behavior>();
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
            if (_script.IsLeft == false)
            {
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
        base.Attack();
        _navMeshAgent.SetDestination(_script.Player.transform.position);
    }

    public override void Defense()
    {
        base.Defense();
        _navMeshAgent.SetDestination(_script.WeakPoint.transform.position);
    }
}
