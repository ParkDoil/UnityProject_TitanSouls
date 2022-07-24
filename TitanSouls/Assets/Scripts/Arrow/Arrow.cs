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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsReturn == false)
            {
                IsReturn = true;
            }
        }
        if (IsReturn == false)
        {
            Vector2 _moveVec = new Vector2(MoveSpeed * Time.deltaTime, 0f);
            transform.Translate(_moveVec);
        }
        else
        {
            _navMeshAgent.SetDestination(_target.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IsReturn = false;
            Destroy(gameObject);
        }
    }
}
