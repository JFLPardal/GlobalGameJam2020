using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedPart : Part
{
    public virtual void DefineDetails(PartType _type, Species _species)
    {
        details = new CombinedPartDetails();
        if (details != null)
        {
            (details as CombinedPartDetails).type = _type;
            (details as CombinedPartDetails).species = _species;
        }

        //print("set: " +(details as CombinedPartDetails).species);
        //print("set: " + (details as CombinedPartDetails).type);
    }

    public PartType GetType()
    {
       // print("get: " + (details as CombinedPartDetails).type);
        return (details as CombinedPartDetails).type;
    }

    public Species GetSpecies()
    {
        //print("get: " + (details as CombinedPartDetails).species);
        return (details as CombinedPartDetails).species;
    }
}
