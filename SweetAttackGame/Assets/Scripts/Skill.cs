using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    public GameObject skillNameLevel;
    public string skillName;
    public string holdName;
    public bool canUpgrade;

    TextMeshProUGUI text;


    void Start()
    {
        skillNameLevel.GetComponent<TextMeshProUGUI>().text = skillName + "  Lv." + PlayerPrefs.GetInt(holdName);
    }

    void Update()
    {
        skillNameLevel.GetComponent<TextMeshProUGUI>().text = skillName + "  Lv." + PlayerPrefs.GetInt(holdName);
    }


}
