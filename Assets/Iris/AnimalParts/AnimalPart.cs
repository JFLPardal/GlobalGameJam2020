using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPart : Part
{
    [SerializeField] Species _species;

    public Species GetSpecies()
    {
        print("get animal: " + _species);
        return _species;
    }
}
