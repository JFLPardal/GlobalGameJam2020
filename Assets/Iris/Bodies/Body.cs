using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;

public class Body : MonoBehaviour
{
    public List<PartSpeciesStruct> currentParts = new List<PartSpeciesStruct>();

    private bool hasNotDropped;

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            var part = new PartSpeciesStruct((PartType)i, Species.UNKNOWN);
            currentParts.Add(part);
        }

        hasNotDropped = true;
    }

    public void UpdateBodyPart(CombinedPart combinedPart)
    {
        print( BodyPartTypeMapper(combinedPart.GetType()));
        for (int i = currentParts.Count - 1; i >= 0; i--)
        {
            if (currentParts[i].type == combinedPart.GetType())
            {
                currentParts[i].species = combinedPart.GetSpecies();
                GetComponent<UpdateBody>().UpdateBodyPart(combinedPart);
                break;
            }
        }
    }

    public void DropFromClaw()
    {
        gameObject.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        hasNotDropped = false;
        Invoke("Destroy", 2f);
    }

    private void OnTriggerStay(Collider other)
    {
        var combinedPart = other.GetComponentInChildren<CombinedPart>();
        if (other.CompareTag("Interactable") && combinedPart != null)
        {
            UpdateBodyPart(combinedPart);
            combinedPart.Destroy();
        }
    }

    public bool HasNotDropped()
    {
        return hasNotDropped;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
