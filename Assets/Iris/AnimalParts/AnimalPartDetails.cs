using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Species
{
    DUCK,
    FISH,
    REDPANDA,
    CROCODILE,
    UNKNOWN
}

public class AnimalPartDetails : PartDetails
{
    public Species species;
}
