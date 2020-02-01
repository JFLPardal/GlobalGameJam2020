using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;
using static LoadPrefabs;

public class JoinParts : MonoBehaviour
{
    PartType animalPartType;
    PartType bodyPartType;

    public bool assembleParts(PartType _bodyPartType, Species _species)
    {
        Debug.Log("assembleParts");
        string bodyPart = BodyPartTypeMapper(_bodyPartType);
        string animalPart = AnimalPartTypeMapper(_bodyPartType);
        string species = AnimalSpeciesMapper(_species);

        Debug.Log(bodyPart + animalPart + species);

        GameObject combinedPart = GetCombinedPart(bodyPart + animalPart + species);
        Instantiate(combinedPart, new Vector3(0, 5, 0), new Quaternion(0,0,0,0));

        //Instantiate()
        return true;
    }
}
