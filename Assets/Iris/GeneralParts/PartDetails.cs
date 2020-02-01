using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    LEGS,
    ARMS,
    HEAD,
    UNKNOWN
}

public class PartDetails
{
    public PartType type;
    public bool isInMixer;
}
