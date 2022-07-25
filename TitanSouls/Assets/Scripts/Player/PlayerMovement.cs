using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigid;
    PlayerInput _input;

    public Transform ShootPosition;

    public float MoveSpeed = 8f;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        _rigid.AddForce(Vector2.zero);

        float xSpeed = _input.X * MoveSpeed;
        float ySpeed = _input.Y * MoveSpeed;

        //Vector2 MoveVec = new Vector2(xSpeed, ySpeed);
        //_rigid.AddForce(MoveVec);

        Vector2 MoveVec = new Vector2(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime);

        transform.Translate(MoveVec);
    }
}
