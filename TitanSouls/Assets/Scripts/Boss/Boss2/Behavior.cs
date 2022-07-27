using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public bool IsLeft { get; private set; }
    
    public GameObject WeakPoint;
    public GameObject Player;

    private float _dot;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PositionCheck();
    }

    void PositionCheck()
    {
        Vector2 distanceVector = Player.transform.position - WeakPoint.transform.position;
        _dot = Vector2.Dot(transform.right, distanceVector.normalized);

        if(_dot > 0)
        {
            IsLeft = true;
        }
        else
        {
            IsLeft = false;
        }
    }
}
