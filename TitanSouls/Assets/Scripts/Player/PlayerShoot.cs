using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Arrow;
    public Transform _firePosition;


    public bool IsFire { get; private set; }

    void Update()
    {
        if (SceneManager.sceneCountInBuildSettings == 1)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsFire == false)
                {
                    IsFire = true;
                    Fire();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrow")
        {
            IsFire = false;
        }
    }
    void Fire()
    {
        Instantiate(Arrow, _firePosition.position, _firePosition.rotation);
    }
}
