using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    public GameObject skillNameLevel;
    public GameObject skillCost;
    public string skillName;
    public string holdName;
    public int cost;
    public bool canUpgrade;

    TextMeshProUGUI text;


    void Start()
    {
        skillNameLevel.GetComponent<TextMeshProUGUI>().text = skillName + "  Lv." + PlayerPrefs.GetInt(holdName);
        GameObject.Find("FireButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("FireCost").ToString();
        GameObject.Find("IceButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("IceCost").ToString();
        GameObject.Find("ElecButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("ElecCost").ToString();
        GameObject.Find("SPText").GetComponent<TextMeshProUGUI>().text = "Skill Points: " + PlayerPrefs.GetInt("SkillPoints").ToString();
    }

    void Update()
    {
        skillNameLevel.GetComponent<TextMeshProUGUI>().text = skillName + "  Lv." + PlayerPrefs.GetInt(holdName);
        GameObject.Find("FireButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("FireCost").ToString();
        GameObject.Find("IceButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("IceCost").ToString();
        GameObject.Find("ElecButton").GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt("ElecCost").ToString();
        GameObject.Find("SPText").GetComponent<TextMeshProUGUI>().text = "Skill Points: " + PlayerPrefs.GetInt("SkillPoints").ToString();
    }


}
