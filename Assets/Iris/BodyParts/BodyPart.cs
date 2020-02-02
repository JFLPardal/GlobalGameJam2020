using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : Part
{

    [SerializeField] PartType _type;


    public PartType GetType()
    {
        print("get body: " + _type);
        return _type;
    }
}
