using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Arrow;

    private float _elapsedTime;

    public bool IsFire { get; private set; }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            
            if (IsFire == false)
            {
                IsFire = true;
                Fire();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrow"&&_elapsedTime >= 0.5f)
        {
            IsFire = false;
            _elapsedTime = 0;
        }
    }
    void Fire()
    {
        Instantiate(Arrow, transform.position, transform.rotation);
    }
}
