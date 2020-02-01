using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinParts : MonoBehaviour
{
    AnimalPartType animalPartType;
    BodyPartType bodyPartType;

    public bool assembleParts(BodyPartType _bodyPartType, AnimalPartType _animalPartType)
    {
        Debug.Log("assembleParts");
        return true;
    }
}
