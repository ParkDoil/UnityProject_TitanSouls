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
    private int _prevBossIndex;

    void Start()
    {
        Invoke("SpawnBoss", 1f);
        _spawnBossIndex = 0;

    }

    void SpawnBoss()
    {
        if (_spawnBossIndex == 0)
        {
            _spawnBossIndex = Random.Range(1, 3);
            _prevBossIndex = _spawnBossIndex;
        }
        else
        {
            if (_prevBossIndex == 1)
            {
                _spawnBossIndex = 2;
            }
            if (_prevBossIndex == 2)
            {
                _spawnBossIndex = 1;
            }
        }

        switch(_spawnBossIndex)
        {
            case 1:
                Instantiate(BossAPrefab, BossASpawnPosition);
                break;
            case 2:
                Instantiate(BossBPrefab, BossBSpawnPosition);
                break;
        }
    }
}
