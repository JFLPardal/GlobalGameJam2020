using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : Part
{
    void Start()
    {
        details = new BodyPartDetails();
        details.type = PartType.ARMS;
        details.isInMixer = false;
    }
}
