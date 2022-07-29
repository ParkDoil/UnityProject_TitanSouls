using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearText : MonoBehaviour
{
    GameObject StageClearUI;

    void Awake()
    {
        StageClearUI = transform.GetChild(0).gameObject;
    }
    void OnEnable()
    {
        GameManager.Instance.OnStageClear.RemoveListener(Activate);

        GameManager.Instance.OnStageClear.AddListener(Activate);
    }
    public void Activate()
    {
        StageClearUI.SetActive(true);
    }
    void OnDisable()
    {
        GameManager.Instance.OnStageClear.RemoveListener(Activate);
    }
}
