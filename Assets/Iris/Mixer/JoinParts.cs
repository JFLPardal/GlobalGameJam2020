using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;
using static LoadPrefabs;

public class JoinParts : MonoBehaviour
{
    [SerializeField] Vector2 finalPartOffset;

    private GameObject smoke;

    public bool assembleParts(PartType _bodyPartType, Species _species)
    {
        string bodyPart = BodyPartTypeMapper(_bodyPartType);
        string animalPart = AnimalPartTypeMapper(_bodyPartType);
        string species = AnimalSpeciesMapper(_species);

        GameObject combinedPartPrefab = GetCombinedPart(bodyPart + animalPart + species);

        if (combinedPartPrefab == null)
            return false;

        CreateCombinedPart(combinedPartPrefab, _bodyPartType, _species);

        Instantiate(combinedPart, transform.position + new Vector3(finalPartOffset.x, 0, finalPartOffset.y), new Quaternion(0,0,0,0));

        //Instantiate()
        return true;
    }

    private void CreateCombinedPart(GameObject prefab, PartType bodyPartType, Species species)
    {
        var combinedPart = Instantiate(prefab, new Vector3(0, 5, 0), new Quaternion(0, 0, 0, 0));
        combinedPart.AddComponent<CombinedPart>();
        combinedPart.GetComponent<CombinedPart>().DefineDetails(bodyPartType, species);
        combinedPart.GetComponent<Renderer>().sortingOrder = 0;
        smoke = Instantiate(GetSmokePrefab(), new Vector3(0, 5, -3), new Quaternion(0, 0, 0, 0));
        Invoke("DestroySmoke", 1f);
    }

    private void DestroySmoke() {
        Destroy(smoke);
    }
}
