using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public void StageClear()
    {
        SceneManager.LoadScene(0);
    }
}