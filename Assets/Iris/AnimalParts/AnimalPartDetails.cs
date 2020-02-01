using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalPartType
{
    LEGS,
    ARMS,
    HEAD,
    UNKNOWN
}

public enum Species
{
    DUCK,
    FISH,
    REDPANDA,
    CROCODILE,
    UNKNOWN
}

public class AnimalPartDetails
{
    public Species species;
    public bool inMixer;
}
