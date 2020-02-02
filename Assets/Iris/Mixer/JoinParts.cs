using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;
using static LoadPrefabs;

public class JoinParts : MonoBehaviour
{
    [SerializeField] Vector2 finalPartOffset;

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

        Instantiate(combinedPart, transform.position + new Vector3(finalPartOffset.x, 0, finalPartOffset.y), new Quaternion(0,0,0,0));

        //Instantiate()
        return true;
    }
}
