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
        if (PlayerPrefs.GetInt("FireCost") <= PlayerPrefs.GetInt("SkillPoints"))
        {
            int fCost = PlayerPrefs.GetInt("FireCost");
            int SP = PlayerPrefs.GetInt("SkillPoints");
            int fLevel = PlayerPrefs.GetInt("FireLevel");
            int hold = SP - fCost;
            PlayerPrefs.SetInt("SkillPoints", hold);
            int hold2 = fCost + fLevel;
            PlayerPrefs.SetInt("FireCost", hold2);
            fLevel++;
            PlayerPrefs.SetInt("FireLevel", fLevel);
            print(PlayerPrefs.GetInt("FireLevel"));
        }
    }
    public void UpgradeIce()
    {
        if (PlayerPrefs.GetInt("IceCost") <= PlayerPrefs.GetInt("SkillPoints"))
        {
            int iCost = PlayerPrefs.GetInt("IceCost");
            int SP = PlayerPrefs.GetInt("SkillPoints");
            int iLevel = PlayerPrefs.GetInt("IceLevel");
            int hold = SP - iCost;
            PlayerPrefs.SetInt("SkillPoints", hold);
            int hold2 = iCost + iLevel;
            PlayerPrefs.SetInt("IceCost", hold2);
            iLevel++;
            PlayerPrefs.SetInt("IceLevel", iLevel);
            print(PlayerPrefs.GetInt("IceLevel"));
        }
    
    }
    public void UpgradeElec()
    {
        if (PlayerPrefs.GetInt("ElecCost") <= PlayerPrefs.GetInt("SkillPoints"))
        {
            int lCost = PlayerPrefs.GetInt("ElecCost");
            int SP = PlayerPrefs.GetInt("SkillPoints");
            int lLevel = PlayerPrefs.GetInt("ElecLevel");
            int hold = SP - lCost;
            PlayerPrefs.SetInt("SkillPoints", hold);
            int hold2 = lCost + lLevel;
            PlayerPrefs.SetInt("ElecCost", hold2);
            lLevel++;
            PlayerPrefs.SetInt("ElecLevel", lLevel);
            print(PlayerPrefs.GetInt("ElecLevel"));
        }
       
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
