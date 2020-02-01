using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParts : MonoBehaviour
{
    private BodyPartType bodyPartType;
    private AnimalPartType animalPartType;

    private BodyPart bodyPart;
    private AnimalPart animalPart;

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
        Debug.Log("collision enter: " + otherTransform.name);
        if (otherTransform.tag.ToLower().Equals("body_part"))
        {
            var _bodyPart = otherTransform.GetComponent<BodyPart>();
            if (tryAddBodyPart(_bodyPart.type()))
            {
                bodyPart = _bodyPart;
                bodyPart.setInMixer(true);

                if (tryJoinParts()) destroyParts();
            }
        }
        else if (otherTransform.tag.ToLower().Equals("animal_part"))
        {
            var _animalPart = otherTransform.GetComponent<AnimalPart>();
            if (tryAddAnimalPart(_animalPart.type()))
            {
                animalPart = _animalPart;
                animalPart.setInMixer(true);

                if (tryJoinParts()) destroyParts();
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
    private bool tryAddAnimalPart(AnimalPartType _animalPartType)
    {
        if (!isAnimalPartSet)
        {
            isAnimalPartSet = true;
            animalPartType = _animalPartType;
            return true;
        }
        return false;
    }

    private bool tryJoinParts()
    {
        Debug.Log("tryJoinParts");
        if (isAnimalPartSet && isBodyPartSet)
            return GetComponent<JoinParts>().assembleParts(bodyPartType, animalPartType);

        return false;
    }

    private void destroyParts()
    {
        animalPart.destroy();
        bodyPart.destroy();
        resetBodyParts();
    }

    private void resetBodyParts()
    {
        isBodyPartSet = false;
        isAnimalPartSet = false;
    }
}
