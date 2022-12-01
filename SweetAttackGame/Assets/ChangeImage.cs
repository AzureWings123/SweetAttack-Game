using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image currentImage;
    public Sprite healthy;
    public Sprite fireEffect;
    public Sprite iceEffect;
    public Sprite lightningEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageChange(int effect)
    {
        if(effect == 0)
        {
            currentImage.sprite = healthy;
        }
        else if(effect == 1)
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
