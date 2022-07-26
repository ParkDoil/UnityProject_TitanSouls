using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject BossBulletA;
    public GameObject BossBulletB;

    GameObject[] _bossBulletA;
    GameObject[] _bossBulletB;

    GameObject[] _targetPool;
    void Awake()
    {
        _bossBulletA = new GameObject[1000];
        _bossBulletB = new GameObject[50];

        Pooling();
    }

    void Pooling()
    {
        for (int i = 0; i < _bossBulletA.Length; ++i)
        {
            _bossBulletA[i] = Instantiate(BossBulletA);
            _bossBulletA[i].SetActive(false);
        }

        for (int i = 0; i < _bossBulletB.Length; ++i)
        {
            _bossBulletB[i] = Instantiate(BossBulletB);
            _bossBulletB[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "BossBulletA":
                _targetPool = _bossBulletA;
                break;
            case "BossBulletB":
                _targetPool = _bossBulletB;
                break;
        }

        for (int i = 0; i < _targetPool.Length; ++i)
        {
            if (_targetPool[i].activeSelf == false)
            {
                _targetPool[i].SetActive(true);
                return _targetPool[i];
            }

        }
        return null;
    }

    void Update()
    {
        
    }
}
