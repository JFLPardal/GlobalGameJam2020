using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPart : Part
{

    void Start()
    {
        details = new AnimalPartDetails() as AnimalPartDetails;
        (details as AnimalPartDetails).species = Species.CROCODILE;
        details.isInMixer = false;
    }

    public virtual void DefineDetails(Species _species)
    {
        if (details != null)
        {
            (details as AnimalPartDetails).species = _species;
        }
    }

    public Species GetSpecies()
    {
        return (details as AnimalPartDetails).species;
    }
}
