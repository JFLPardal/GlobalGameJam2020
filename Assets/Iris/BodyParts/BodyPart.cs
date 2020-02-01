using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : Part
{

    void Start()
    {
        details = new BodyPartDetails();
        (details as BodyPartDetails).type = PartType.ARMS;
        details.isInMixer = false;
    }
    public virtual void DefineDetails(PartType _type)
    {
        if (details != null)
        {
            (details as BodyPartDetails).type = _type;
        }
    }

    public PartType GetType()
    {
        return (details as BodyPartDetails).type;
    }
}
