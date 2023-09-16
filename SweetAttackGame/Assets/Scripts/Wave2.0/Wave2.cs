using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave2
{
    public string waveName;
    public Group[] groups;
    public Transform[] spawnPoints;

    private int currentGroupNumber = -1;

    public int amountOfEnemies()
    {
        int amount = 0;
        foreach (Group group in groups)
        {
            amount += group.totalAmount();
        }
        return amount;
    }

    public void StartWave()
    {   
        NextGroup();
    }

    private void NextGroup()
    {
        if(currentGroupNumber + 1 < groups.Length)
        {
            currentGroupNumber++;
            groups[currentGroupNumber].Spawn(spawnPoints);
        }
        else
        {
            // finished wave
        }
    }
}
