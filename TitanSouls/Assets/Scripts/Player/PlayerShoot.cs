using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Arrow;
    public Transform FireLocation;

    public bool IsFire { get; private set; }

    void Update()
    {
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
            IsFire = false;
        }
    }

    void Fire()
    {
        Instantiate(Arrow, FireLocation.position, FireLocation.rotation);
    }
}
