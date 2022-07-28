using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossAPrefab;
    public GameObject BossBPrefab;

    public Transform BossASpawnPosition;
    public Transform BossBSpawnPosition;

    private int _spawnBossIndex;

    void Start()
    {
        Invoke("SpawnBoss", 1f);

    }

    void SpawnBoss()
    {
        _spawnBossIndex = Random.Range(1, 3);

        switch(_spawnBossIndex)
        {
            case 1:
                Instantiate(BossAPrefab, BossASpawnPosition);
                GameManager.Instance.BossAText();
                break;
            case 2:
                Instantiate(BossBPrefab, BossBSpawnPosition);
                GameManager.Instance.BossBText();
                break;
        }
    }
}
