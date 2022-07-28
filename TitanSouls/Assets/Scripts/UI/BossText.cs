using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{
    private GameObject[] _childs;
    private int _childCount;

    void Awake()
    {
        _childCount = transform.childCount;
        _childs = new GameObject[_childCount];

        for(int i = 0; i < _childCount; ++i)
        {
            _childs[i] = transform.GetChild(i).gameObject;
        }
    }
    void OnEnable()
    {
        GameManager.Instance.OnBossA.RemoveListener(ActivateA);
        GameManager.Instance.OnBossB.RemoveListener(ActivateB);

        GameManager.Instance.OnBossA.AddListener(ActivateA);
        GameManager.Instance.OnBossB.AddListener(ActivateB);
    }

    public void ActivateA()
    {
        _childs[0].SetActive(true);

        Invoke("DeactivateA", 1f);
    }
    public void DeactivateA()
    {
        _childs[0].SetActive(false);
    }

    public void ActivateB()
    {
        _childs[1].SetActive(true);

        Invoke("DeactivateA", 1f);
    }
    public void DeactivateB()
    {
        _childs[1].SetActive(false);
    }

    public void OnDisable()
    {
        GameManager.Instance.OnBossA.RemoveListener(ActivateA);
        GameManager.Instance.OnBossB.RemoveListener(ActivateB);
    }
}
