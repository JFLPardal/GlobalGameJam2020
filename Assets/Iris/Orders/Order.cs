using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;

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
        /*expectedParts.Add(new PartSpeciesStruct(PartType.ARMS, Species.UNKNOWN));
        expectedParts.Add(new PartSpeciesStruct(PartType.LEGS, Species.UNKNOWN));
        expectedParts.Add(new PartSpeciesStruct(PartType.HEAD, Species.UNKNOWN));*/
    }

    private void GenerateRandomParts()
    {
        int newPartsCount = Random.Range(1, 3);

        for (int i = 0; i < newPartsCount; i++)
        {
            var newPart = new PartSpeciesStruct(GetRandomPart(), GetRandomSpecies());
            expectedParts.Add(newPart);
        }
    }


}
