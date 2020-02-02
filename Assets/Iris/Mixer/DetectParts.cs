using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadPrefabs;

public class DetectParts : MonoBehaviour
{
    private PartType bodyPartType;
    private Species species;

    private bool isBodyPartSet;
    private bool isAnimalPartSet;

    private GameObject smoke;

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
                if (tryJoinParts()) resetBodyParts();
                smoke = Instantiate(GetSmokePrefab(), otherTransform.position, new Quaternion(0, 0, 0, 0));
                _bodyPart.Destroy();
                Invoke("DestroySmoke", 1f);
            }
            else if (otherTransform.tag.ToLower().Equals("animal_part"))
            {
                if (tryJoinParts()) resetBodyParts();
                smoke = Instantiate(GetSmokePrefab(), otherTransform.position, new Quaternion(0, 0, 0, 0));
                _animalPart.Destroy();
                Invoke("DestroySmoke", 1f);
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

    private void DestroySmoke()
    {
        Destroy(smoke);
    }
}
