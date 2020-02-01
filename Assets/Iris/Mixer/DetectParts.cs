using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParts : MonoBehaviour
{
    private BodyPartType bodyPartType;
    private Species species;

    private bool isBodyPartSet;
    private bool isAnimalPartSet;


    void Start()
    {
        isBodyPartSet = false;
        isAnimalPartSet = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherTransform = collision.transform;
        if (otherTransform.tag.ToLower().Equals("body_part"))
        {
            var _bodyPart = otherTransform.GetComponent<BodyPart>();
            if (tryAddBodyPart(_bodyPart.type()))
            {
                if (tryJoinParts()) resetBodyParts();
                _bodyPart.destroy();
            }
        }
        else if (otherTransform.tag.ToLower().Equals("animal_part"))
        {
            var _animalPart = otherTransform.GetComponent<AnimalPart>();
            if (tryAddAnimalPart(_animalPart.species()))
            {
                if (tryJoinParts()) resetBodyParts();
                _animalPart.destroy();
            }
        }
    }

    private bool tryAddBodyPart(BodyPartType _bodyPartType)
    {
        if (!isBodyPartSet)
        {
            isBodyPartSet = true;
            bodyPartType = _bodyPartType;
            return true;
        }
        return false;
    }
    private bool tryAddAnimalPart(Species _species)
    {
        if (!isAnimalPartSet)
        {
            isAnimalPartSet = true;
            species = _species;
            return true;
        }
        return false;
    }

    private bool tryJoinParts()
    {
        if (isAnimalPartSet && isBodyPartSet)
            return GetComponent<JoinParts>().assembleParts(bodyPartType, species);

        return false;
    }

    private void resetBodyParts()
    {
        isBodyPartSet = false;
        isAnimalPartSet = false;
        species = Species.UNKNOWN;
        bodyPartType = BodyPartType.UNKNOWN;
    }
}
