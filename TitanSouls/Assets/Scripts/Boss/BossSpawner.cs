using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossAPrefab;
    // GameObject BossBPrefab;

    public Transform BossASpawnPosition;
    // Transform BossBSpawnPosition;

    void Start()
    {
        Invoke("SpawnBoss", 1f);
    }

    void SpawnBoss()
    {
        int _spawnBossIndex = Random.Range(1, 3);

        switch(_spawnBossIndex)
        {
            case 1:
                Instantiate(BossAPrefab, BossASpawnPosition);
                break;
            case 2:
                Instantiate(BossAPrefab, BossASpawnPosition);
                break;
        }
    }
}
