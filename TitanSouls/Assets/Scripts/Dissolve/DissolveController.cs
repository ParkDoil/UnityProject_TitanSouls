using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public enum State
    {
        Die, Alive
    }

    public State state = State.Alive;
    Material _material;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        switch (state)
        {
            case State.Die:
                UpdateDie();
                break;

            case State.Alive:
                UpdateAlive();
                break;
        }
    }

    void UpdateDie()
    {
        float _dissolveAmount = _material.GetFloat("_DissolveAmount");
        if (_dissolveAmount < 1f)
        {
            _material.SetFloat("_DissolveAmount", _dissolveAmount + (0.5f * Time.deltaTime));
        }
        else
        {
            _material.SetFloat("_DissolveAmount", 1f);
        }
    }
    void UpdateAlive()
    {
        _material.SetFloat("_DissolveAmount", 0f);
    }

    public void ChangeState(State _nextState)
    {
        state = _nextState;
    }
}
