using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Arrow;

    public Transform _fireLoaction;
    
    public bool IsFire { get; private set; }
    void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrow")
        {
            IsFire = false;
        }
    }
    void Fire()
    {
        Instantiate(Arrow, _fireLoaction.position, _fireLoaction.rotation);
    }
}
