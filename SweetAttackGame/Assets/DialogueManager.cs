using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public Button startButton;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        gameObject.SetActive(true);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started convo! Loaded messages: " + messages.Length);
        DisplayMessage();
        

        startButton.enabled = false;
    }

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Convo end");
            isActive = false;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isActive == true)
        {
            NextMessage();
        }
    }
}
