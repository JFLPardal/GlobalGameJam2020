using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadPrefabs;

public class Box : MonoBehaviour
{
    BoxDetails boxDetails;
    bool isEmpty;

    void Start()
    {
        boxDetails = new BoxDetails();
        boxDetails.type = BoxType.BODY;
        boxDetails.part = PartType.ARMS;
        boxDetails.species = Species.UNKNOWN;
        boxDetails.boxTypeName = "Barms";
        isEmpty = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetPart();
        }
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

    public void GetPart()
    {
        Debug.Log("GetPart");
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
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        GameObject newPart = Instantiate(prefab, newPos, new Quaternion(0, 0, 0, 0));
        if (bodyPart)
        {
            newPart.AddComponent<BodyPart>();
            newPart.GetComponent<BodyPart>().DefineDetails(boxDetails.part);
        }
        else
        {
            newPart.AddComponent<AnimalPart>();
            newPart.GetComponent<AnimalPart>().DefineDetails(boxDetails.part);
        }
    }

}
