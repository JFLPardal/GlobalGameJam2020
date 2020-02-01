using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPart : MonoBehaviour
{
    AnimalPartDetails details;

    void Start()
    {
        details = new AnimalPartDetails();
        details.type = AnimalPartType.ARMS;
        details.species = Species.CHICKEN;
        details.inMixer = false;
    }

    public void defineDetails(AnimalPartType _type, Species _species)
    {
        if (details != null)
        {
            details.species = _species;
            details.type = _type;
        }
    }

    public bool isInMixer()
    {
        return details.inMixer;
    }

    public void setInMixer(bool value)
    {
        details.inMixer = value;
    }

    public AnimalPartType type()
    {
        return details.type;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
