using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParts : MonoBehaviour
{
    private PartType bodyPartType;
    private Species species;

    private bool isBodyPartSet;
    private bool isAnimalPartSet;


    void Start()
    {
        isBodyPartSet = false;
        isAnimalPartSet = false;
    }
    
    protected void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Part>() != null && !other.GetComponent<Part>().IsPickedUp())
        {
            print("la para dentro");
            //var transformVector = other.GetComponentsInChildren<Transform>();
            //var otherTransform = transformVector[1];
            var otherTransform = other.GetComponentInChildren<Transform>();
            if (otherTransform.tag.ToLower().Equals("body_part"))
            {
                var _bodyPart = otherTransform.GetComponent<BodyPart>();
                if (tryAddBodyPart(_bodyPart.GetType()))
                {
                    if (tryJoinParts()) resetBodyParts();
                    _bodyPart.Destroy();
                }
            }
            else if (otherTransform.tag.ToLower().Equals("animal_part"))
            {
                var _animalPart = otherTransform.GetComponent<AnimalPart>();
                if (tryAddAnimalPart(_animalPart.GetSpecies()))
                {
                    if (tryJoinParts()) resetBodyParts();
                    _animalPart.Destroy();
                }
            }
        }
    }
    private bool tryAddBodyPart(PartType _bodyPartType)
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
        bodyPartType = PartType.UNKNOWN;
    }
}
