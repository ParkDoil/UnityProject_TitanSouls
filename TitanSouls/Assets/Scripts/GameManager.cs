using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent OnBossA = new UnityEvent();
    public UnityEvent OnBossB = new UnityEvent();

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
}