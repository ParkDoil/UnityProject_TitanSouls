using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : MonoBehaviour
{
    private int _pattern;
    private float _elapsedTime;

    private Vector3 _spin = new Vector3(0f, 0f, 0.2f);

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 3f)
        {
            _pattern = Random.Range(1, 3);
            switch (_pattern)
            {
                case 1:
                    _spin = new Vector3(0f, 0f, 0.2f);
                    _elapsedTime = 0f;
                    break;
                case 2:
                    _spin = new Vector3(0f, 0f, -0.2f);
                    _elapsedTime = 0f;
                    break;
            }
        }
        transform.Rotate(_spin);

    }
}
