using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void UpgradeFire()
    {
        int fLevel = PlayerPrefs.GetInt("FireLevel");
        fLevel++;
        PlayerPrefs.SetInt("FireLevel", fLevel);
        print(PlayerPrefs.GetInt("FireLevel"));
    }
    public void UpgradeIce()
    {
        int iLevel = PlayerPrefs.GetInt("IceLevel");
        iLevel++;
        PlayerPrefs.SetInt("IceLevel", iLevel);
    }
    public void UpgradeElec()
    {
        int lLevel = PlayerPrefs.GetInt("ElecLevel");
        lLevel++;
        PlayerPrefs.SetInt("ElecLevel", lLevel);
    }
    public void contButton()
    {
        if(!PlayerPrefs.HasKey("NextLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level2"));
            print("Defaulted");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("NextLevel"));
        }
        
    }
}
