using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPart : MonoBehaviour
{
    AnimalPartDetails details;

    void Start()
    {
        details = new AnimalPartDetails();
        details.species = Species.CROCODILE;
        details.inMixer = false;
    }

    public void defineDetails(AnimalPartType _type, Species _species)
    {
        if (details != null)
        {
            details.species = _species;
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

    public Species species()
    {
        return details.species;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
