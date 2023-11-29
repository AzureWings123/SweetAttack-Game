using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Image backImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    Background[] currentBackgrounds;
    
    int activeMessage = 0;
    int backgroundNum = 0;
    bool change = false;
    public static bool isActive = false;

    public Button startButton;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenDialogue(Message[] messages, Actor[] actors, Background[] backgrounds)
    {
        gameObject.SetActive(true);
        currentMessages = messages;
        currentActors = actors;
        currentBackgrounds = backgrounds;
        activeMessage = 0;
        backgroundNum = 0;
        isActive = true;

        Debug.Log("Started convo! Loaded messages: " + messages.Length);
        DisplayMessage();
        

        startButton.enabled = false;
    }

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        change = messageToDisplay.changeBkgd;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        Background backToDisplay = currentBackgrounds[backgroundNum];
        backImage.sprite = backToDisplay.sprite;

    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            ChangeBackground();
        }
        else
        {
            Debug.Log("Convo end");
            isActive = false;
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isActive == true)
        {
            NextMessage();
        }
    }

    void ChangeBackground()
    {
        if (change == true)
        {
            backgroundNum++;
        }
    }
}
