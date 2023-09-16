using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveSystem2 : MonoBehaviour
{
    public Wave2[] waves;
    public Transform[] spawnPoints;

    private int currentWaveNumber = -1;

    public void StartWaves()
    {
        NextWave();
    }

    private void NextWave()
    {
        if(currentWaveNumber + 1 < waves.Length)
        {
            currentWaveNumber++;
            waves[currentWaveNumber].StartWave();
        }
        else
        {
            // finished waves
        }
    }
}
