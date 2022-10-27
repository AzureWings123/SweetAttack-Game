using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffect : MonoBehaviour
{
    [SerializeField] private float startingEffect = 0;
    public Image currentImage;
    public Sprite healthy;
    public Sprite fireEffect;
    public Sprite iceEffect;
    public Sprite lightningEffect;
    public float currentEffect { get; private set; }
    private void Awake()
    {
        currentEffect = startingEffect;
    }

    private void Start()
    {
    }
    public void ChangeEffect(int effect)
    {
        if (currentEffect != 0) //If enemy isn't currently healthy
        {
            currentEffect = 0; //TEMP: Change to do reactions later
            ImageChange(0);
        }
        else // if healthy, change to new status effect
        {
            currentEffect = effect;
            ImageChange(effect);
        }
    }
    public void ImageChange(int effect)
    {
        if (effect == 0)
        {
            currentImage.sprite = healthy;
        }
        else if (effect == 1)
        {
            currentImage.sprite = iceEffect;
        }
        else if (effect == 2)
        {
            currentImage.sprite = lightningEffect;
        }
        else if (effect == 3)
        {
            currentImage.sprite = fireEffect;
        }

    }
}

