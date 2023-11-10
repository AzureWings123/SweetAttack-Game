using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Background[] backgrounds;

    public GameObject messageWindow;
    public GameObject startButton;
    public GameObject backgroundWindow;


    public void StartDialogue()
    {
        messageWindow.SetActive(true);
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors, backgrounds);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
    public bool changeBkgd;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}

[System.Serializable]
public class Background
{
    public int bkgdNum;
    public Sprite sprite;
}