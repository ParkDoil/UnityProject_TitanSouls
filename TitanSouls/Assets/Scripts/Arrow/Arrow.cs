using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Rigidbody2D _rigid;

    private Transform _target;
    private Transform _collisionPosition;

    public float MoveSpeed;
    public bool IsReturn { get; private set; }
    public bool IsCollision { get; private set; }

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _rigid = GetComponent<Rigidbody2D>();
        _collisionPosition = GetComponent<Transform>();
    }

    void Update()
    {
        IsReturn = false;

        Vector2 vec = new Vector2(90f, 0f);
        transform.Rotate(vec);

        if (Input.GetMouseButton(1))
        {
            IsReturn = true;
            IsCollision = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            IsReturn = false;
        }

        if (IsReturn == false && IsCollision == false)
        {
            _navMeshAgent.ResetPath();
            transform.Translate(Vector2.right * MoveSpeed);
        }
        else if(IsReturn == false && IsCollision == true)
        {
            transform.position = _collisionPosition.position;
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

        if (collision.tag == "Wall" || collision.tag == "WeakPoint")
        {
            _collisionPosition.position = transform.position;
            IsCollision = true;
        }

        if(collision.tag == "Boss")
        {
            if (IsReturn == false)
            {
                _collisionPosition.position = transform.position;
                IsCollision = true;
            }
        }
    }
}
