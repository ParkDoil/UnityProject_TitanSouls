using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    GameObject GameOverUI;

    void Awake()
    {
        GameOverUI = transform.GetChild(0).gameObject;
    }
    void OnEnable()
    {
        GameManager.Instance.OnGameOver.RemoveListener(Activate);

        GameManager.Instance.OnGameOver.AddListener(Activate);
    }
    public void Activate()
    {
        GameOverUI.SetActive(true);
    }
    void OnDisable()
    {
        GameManager.Instance.OnGameOver.RemoveListener(Activate);
    }
}
