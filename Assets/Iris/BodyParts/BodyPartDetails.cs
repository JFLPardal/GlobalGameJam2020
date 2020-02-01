﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartType
{
    LEGS,
    ARMS,
    HEAD,
    UNKNOWN
}

public class BodyPartDetails
{
    public BodyPartType type;
    public bool inMixer;
}