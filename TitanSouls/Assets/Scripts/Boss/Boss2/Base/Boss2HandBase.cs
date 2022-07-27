using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HandBase : MonoBehaviour
{
    public bool IsAttackState;

    public virtual void Attack()
    {
        IsAttackState = true;
    }

    public virtual void Defense()
    {
        IsAttackState = false;
    }
}
