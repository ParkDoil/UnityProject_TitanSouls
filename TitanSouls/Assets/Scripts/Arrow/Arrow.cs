using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;

    private Transform _target;

    public float MoveSpeed = 1f;
    public bool IsReturn { get; private set; }

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 vec = new Vector2(90f, 0f);
        transform.Rotate(vec);

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsReturn == false)
            {
                IsReturn = true;
            }
        }
        if (IsReturn == false)
        {
            transform.Translate(Vector2.up * MoveSpeed);
        }
        else
        {
            _navMeshAgent.SetDestination(_target.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && IsReturn == true)
        {
            IsReturn = false;
            Destroy(gameObject);
        }

        if(collision.tag == "wall")
        {
            IsReturn = true;
        }
    }
}
