using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour
{
    public GameObject _controlText;

    private bool _isShow;
    void Start()
    {
        _controlText = transform.GetChild(0).gameObject;
        _isShow = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isShow = !_isShow;
        }

        if (_isShow == true)
        {
            Time.timeScale = 0f;
            _controlText.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _controlText.SetActive(false);
        }

    }
}
