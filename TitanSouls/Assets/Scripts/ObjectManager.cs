using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject BossBulletA;
    public GameObject BossBulletB;

    GameObject[] _bossBulletA;
    GameObject[] _bossBulletB;

    void Awake()
    {
        _bossBulletA = new GameObject[50];
        _bossBulletB = new GameObject[1000];

        Pooling();
    }

    void Pooling()
    {
        for(int i = 0; i < _bossBulletA.Length; ++i)
        {
            _bossBulletA[i] = Instantiate(BossBulletA);
        }

        for (int i = 0; i < _bossBulletB.Length; ++i)
        {
            _bossBulletB[i] = Instantiate(BossBulletB);
        }
    }

    void Update()
    {
        
    }
}
