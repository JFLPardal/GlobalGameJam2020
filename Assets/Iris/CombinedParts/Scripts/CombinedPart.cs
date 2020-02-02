using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedPart : Part
{
    private void Start()
    {
        details = new CombinedPartDetails();
        (details as CombinedPartDetails).species = Species.REDPANDA;
    }
    public virtual void DefineDetails(PartType _type, Species _species)
    {
        if (details != null)
        {
            (details as CombinedPartDetails).type = _type;
            (details as CombinedPartDetails).species = _species;
        }
    }

    public PartType GetType()
    {
        return (details as CombinedPartDetails).type;
    }

    public Species GetSpecies()
    {
        return (details as CombinedPartDetails).species;
    }
}
