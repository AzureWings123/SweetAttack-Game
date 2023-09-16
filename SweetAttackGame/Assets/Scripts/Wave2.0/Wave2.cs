using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Wave2
{
    public string waveName;
    // public float spawnInterval;

    public Group[] groups;

    public int totalNumberOfEnemies()
    {
        int output = 0;
        foreach (Group group in groups)
        {
            output += group.totalNumberOfEnemies();
        }
        return output;
    }

    public int numberOfGroupsOfEnemies()
    {
        return groups.Length;
    }
}
