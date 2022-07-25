using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Arrow;
    private int _arrowCount;

    public bool IsFire { get; private set; }

    void Update()
    {
        if(_arrowCount >= 2)
        {
            IsFire = false;
        }

        _arrowCount = 1;
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (IsFire == false)
            {
                IsFire = true;
                Fire();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            ++_arrowCount;
        }
    }

    void Fire()
    {
        --_arrowCount;
        Instantiate(Arrow, transform.position, transform.rotation);
    }
}
