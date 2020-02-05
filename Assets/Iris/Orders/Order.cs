using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;
using static LoadPrefabs;

public class PartSpeciesStruct
{
    public PartType type;
    public Species species;

    public PartSpeciesStruct(PartType _type, Species _species)
    {
        type = _type;
        species = _species;
    }

}

public class Order : MonoBehaviour
{
    public List<PartSpeciesStruct> expectedParts = new List<PartSpeciesStruct>();

    void Start()
    {
        GenerateRandomParts();
    }

    private void GenerateRandomParts()
    {
        for (int i = 0; i < 3; i++)
        {
            var newPart = new PartSpeciesStruct((PartType)i, GetRandomSpecies());
            expectedParts.Add(newPart);
        }
        //CreateOrderMiniBody();
    }

    private void CreateOrderMiniBody()
    {
        
        GameObject legsPrefab = GetCombinedPart(PartSpeciesStructNameMapper(expectedParts.GetLegs()));
        GameObject armsPrefab = GetCombinedPart(PartSpeciesStructNameMapper(expectedParts.GetArms()));
        GameObject headPrefab = GetCombinedPart(PartSpeciesStructNameMapper(expectedParts.GetHead()));
        Debug.Log(legsPrefab);
        var pos = transform.position;

        GameObject legs = Instantiate(legsPrefab, new Vector3(pos.x, pos.y, pos.z), new Quaternion(0,0,0,0));
        GameObject arms = Instantiate(armsPrefab, new Vector3(pos.x, pos.y + 1, pos.z), new Quaternion(0, 0, 0, 0));
        GameObject head = Instantiate(headPrefab, new Vector3(pos.x, pos.y + 2, pos.z), new Quaternion(0, 0, 0, 0));

        legs.transform.parent = transform;
        arms.transform.parent = transform;
        head.transform.parent = transform;

    }


}
