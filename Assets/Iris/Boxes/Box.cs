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
                    GameObject bodyPart = GetBodyPart(boxDetails.boxTypeName);
                    Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    Instantiate(bodyPart, newPos, new Quaternion(0, 0, 0, 0));
                    break;
                case BoxType.ANIMAL:
                    GameObject animalPart = GetAnimalPart(boxDetails.boxTypeName);
                    newPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    Instantiate(animalPart, newPos, new Quaternion(0, 0, 0, 0));
                    break;
            }
        }
    }

    public void SetIsEmpty(bool value)
    {
        isEmpty = value;
    }


}
