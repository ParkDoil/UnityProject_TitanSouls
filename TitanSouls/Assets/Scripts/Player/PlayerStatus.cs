using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss" || collision.tag == "EnemyBullet")
        {
            gameObject.SetActive(false);
            GameManager.Instance.End();
        }
    }
}
