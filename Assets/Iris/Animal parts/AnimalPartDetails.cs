using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalPartType
{
    LEGS,
    ARMS,
    HEAD
}

public enum Species
{
    CHICKEN,
    FISH,
    PARROT
}

public class AnimalPartDetails
{
    public AnimalPartType type;
    public Species species;
    public bool inMixer;
}
