using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadPrefabs;

public class Box : Interactable
{
    BoxDetails boxDetails;
    bool isEmpty;

    public BoxType _type = BoxType.BODY;
    public PartType _bodyPart = PartType.ARMS;
    public Species _species = Species.UNKNOWN;

    void Start()
    {
        boxDetails = new BoxDetails();
        boxDetails.type = _type;
        boxDetails.part = _bodyPart;
        boxDetails.species = _species; 

        string finalNamePart = _species.ToString().ToLower();

        if (_bodyPart != PartType.UNKNOWN)
            finalNamePart = _bodyPart.ToString().ToLower();
        boxDetails.boxTypeName = _type.ToString().Substring(0, 1) + finalNamePart;

        isEmpty = true;
    }
    
    public void DefineBoxDetails(BoxType _type, PartType _part, Species _species = Species.UNKNOWN)
    {
        boxDetails.type = _type;
        boxDetails.species = _species;
        boxDetails.part = _part;

        string finalNamePart = _species.ToString().ToLower();

        if(_part != PartType.UNKNOWN)
            finalNamePart = _part.ToString().ToLower();

        boxDetails.boxTypeName = _type.ToString().Substring(0, 1) + finalNamePart;

        Debug.Log("Box: " + boxDetails.boxTypeName);
    }

    public override void Interact(Transform transform)
    {
        if (isEmpty)
        {
            switch (boxDetails.type)
            {
                case BoxType.BODY:
                    GameObject bodyPartPrefab = GetBodyPart(boxDetails.boxTypeName);
                    CreateNewPart(bodyPartPrefab, true);
                    break;
                case BoxType.ANIMAL:
                    GameObject animalPartPrefab = GetAnimalPart(boxDetails.boxTypeName);
                    CreateNewPart(animalPartPrefab, false);
                    break;
            }
        }
    }

    public void SetIsEmpty(bool value)
    {
        isEmpty = value;
    }

    private void CreateNewPart(GameObject prefab, bool bodyPart)
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 1);

        GameObject newPart = Instantiate(prefab, newPos, new Quaternion(0, 0, 0, 0));
        if (bodyPart)
        {
            newPart.AddComponent<BodyPart>();
            newPart.GetComponent<BodyPart>().DefineDetails(boxDetails.part);
        }
        else
        {
            newPart.AddComponent<AnimalPart>();
            newPart.GetComponent<AnimalPart>().DefineDetails(boxDetails.species);
        }
    }

}
