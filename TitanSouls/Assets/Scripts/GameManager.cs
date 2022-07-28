using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent OnBossA = new UnityEvent();
    public UnityEvent OnBossB = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();

    private bool _isEnd = false;
    void Update()
    {
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            _isEnd = false;
            SceneManager.LoadScene(0);
        }
    }

    public void StageClear()
    {
        SceneManager.LoadScene(0);
    }

    public void BossAText()
    {
        OnBossA.Invoke();
    }
    public void BossBText()
    {
        OnBossB.Invoke();
    }

    public void End()
    {
        _isEnd = true;
        OnGameOver.Invoke();
    }

}