using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript instance { get; private set; }
    private AudioSource source;
    [SerializeField] private AudioClip BattleTheme;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    void Start()
    {
        SoundManagerScript.instance.PlaySound(BattleTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
