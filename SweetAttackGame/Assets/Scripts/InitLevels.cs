using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            PlayerPrefs.SetInt("FireLevel", 1);
            PlayerPrefs.SetInt("IceLevel", 1);
            PlayerPrefs.SetInt("ElecLevel", 1);
            PlayerPrefs.SetInt("FireCost", 1);
            PlayerPrefs.SetInt("IceCost", 1);
            PlayerPrefs.SetInt("ElecCost", 1);
            PlayerPrefs.SetInt("SkillPoints", 0);
   
    }

}
