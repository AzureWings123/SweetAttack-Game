using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAndAmount
{
    public GameObject enemy;
    public int amount;
    public float delay;
    public bool spawnNextInstantlayWhenAllDead = true;
}
