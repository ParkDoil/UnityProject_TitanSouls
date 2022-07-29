using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public bool IsLeft { get; private set; }
    public bool IsDead { get; private set; }
    
    public GameObject WeakPoint;
    public GameObject Player;

    private float _dot;

    private int _childCount;

    SpriteRenderer[] _spriteRenderer;

    void Start()
    {
        _childCount = transform.childCount;
        Player = GameObject.FindGameObjectWithTag("Player");

        _spriteRenderer = new SpriteRenderer[_childCount];

        for (int i = 0; i < _childCount; ++i)
        {
            _spriteRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (WeakPoint.GetComponent<Boss2WeakPoint>().IsHit == true)
        {
            IsDead = true;

            GameManager.Instance.StageClearText();
            StartCoroutine(DieAnimation());
        }

        if (IsDead == false)
        {
            PositionCheck();

        }
    }

    IEnumerator DieAnimation()
    {
        float _fadeCount = 1f;

        while (_fadeCount > 0f)
        {
            _fadeCount -= 0.1f;

            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < _childCount; ++i)
            {
                _spriteRenderer[i].color = new Color(255f, 255f, 255f, _fadeCount);
            }
        }

        Die();
    }

    void PositionCheck()
    {
        Vector2 distanceVector = Player.transform.position - WeakPoint.transform.position;
        _dot = Vector2.Dot(transform.right, distanceVector.normalized);

        if(_dot > 0)
        {
            IsLeft = true;
        }
        else
        {
            IsLeft = false;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.StageClear();
    }
}
