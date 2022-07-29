using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent OnBossA = new UnityEvent();
    public UnityEvent OnBossB = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();
    public UnityEvent OnStageClear = new UnityEvent();

    private bool _isEnd = false;
    void Update()
    {
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            _isEnd = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
    }
    public void StageClearText()
    {
        OnStageClear.Invoke();
    }
    public void StageClear()
    {
        SceneManager.LoadScene(1);
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
    
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}