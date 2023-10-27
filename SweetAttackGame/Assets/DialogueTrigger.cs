using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public GameObject messageWindow;
    public GameObject startButton;


    public void StartDialogue()
    {
        messageWindow.SetActive(true);
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
