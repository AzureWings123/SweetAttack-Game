using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    [SerializeField] private float startingEffect = 0;
    public float currentEffect { get; private set; }
    private void Awake()
    {
        currentEffect = startingEffect;
    }
    public void ChangeEffect(int effect)
    {
        if (currentEffect != 0) //If enemy isn't currently healthy
        {
            currentEffect = 0; //TEMP: Change to do status conditions later
        }
        else
        {
            currentEffect = effect;
        }
            
    }
}
