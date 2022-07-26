using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool IsRotate;

    private float _rotateSpeed = 10f;

    void Update()
    {
        if (IsRotate == true)
        {
            transform.Rotate(Vector3.forward * _rotateSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }
}
