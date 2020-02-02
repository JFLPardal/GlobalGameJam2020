using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundEvents
{
    PICKUP,
    THROWMIXER,
    DROP,
    SHOOT,
    COMBINED,
    DROPBODY
}

public class SoundController : MonoBehaviour
{

    public AudioClip pickup;
    public AudioClip throwMixer;
    public AudioClip drop;
    public AudioClip shoot;
    public AudioClip combined;
    public AudioClip dropBody;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponents<AudioSource>()[1];
    }

    public void PlaySound(SoundEvents eventName)
    {
        switch (eventName)
        {
            case SoundEvents.PICKUP:
                source.clip = pickup;
                source.Play();
                source.loop = false;
                break;
            case SoundEvents.THROWMIXER:
                source.clip = pickup;
                source.Play();
                source.loop = false;
                break;
            case SoundEvents.DROP:
                source.clip = drop;
                source.Play();
                source.loop = false;
                break;
            case SoundEvents.SHOOT:
                source.clip = shoot;
                source.Play();
                source.loop = false;
                break;
            case SoundEvents.COMBINED:
                source.clip = combined;
                source.Play();
                source.loop = false;
                break;
            case SoundEvents.DROPBODY:
                source.clip = dropBody;
                source.Play();
                source.loop = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
