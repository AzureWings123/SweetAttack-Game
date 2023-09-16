using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Group
{
    public EnemyAndAmount[] enemies;
    public float maxDelay;

    public int totalAmount()
    {
        int total = 0;
        foreach (EnemyAndAmount enemy in enemies)
        {
            total += enemy.amount;
        }
        return total;
    }

    public void Spawn(Transform[] spawnPoints)
    {
        foreach (EnemyAndAmount enemy in enemies)
        {
            enemy.Spawn(spawnPoints);
        }
    }
}
