﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxType
{
    EMPTY,
    BODY,
    ANIMAL
}

public class BoxDetails
{
    public BoxType type;
    public Species species;
    public PartType part;
    public string boxTypeName;
}
