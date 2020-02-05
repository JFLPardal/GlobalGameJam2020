using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;
using static LoadPrefabs;

public class UpdateBody : MonoBehaviour
{
    public void UpdateBodyPart(CombinedPart part)
    {
        switch (part.GetType())
        {
            case PartType.ARMS:
                UpdateArms(part);
                break;
            case PartType.LEGS:
                UpdateLegs(part);
                break;
            case PartType.HEAD:
                UpdateHead(part);
                break;
        }
    }

    private void UpdateLegs(CombinedPart legs)
    {
        string fullName = CombinedPartNameMapper(legs);
        var prefab = GetCombinedPart(fullName);

        var childLegs = GetBodyPart("legs");

        var newLegs = Instantiate(prefab, childLegs.transform.position, childLegs.transform.rotation);
        newLegs.transform.parent = transform;
        newLegs.tag = "legs";
        newLegs.GetComponent<Rigidbody>().isKinematic = true;
        newLegs.GetComponent<Rigidbody>().useGravity = false;
        Destroy(childLegs);
    }

    private void UpdateArms(CombinedPart arms)
    {
        string fullName = CombinedPartNameMapper(arms);
        var prefab = GetCombinedPart(fullName);

        var childLegs = GetBodyPart("arms");
        var newLegs = Instantiate(prefab, childLegs.transform.position, childLegs.transform.rotation);
        newLegs.transform.parent = transform;
        newLegs.tag = "arms";
        newLegs.GetComponent<Rigidbody>().isKinematic = true;
        newLegs.GetComponent<Rigidbody>().useGravity = false;
        Destroy(childLegs);
    }

    private void UpdateHead(CombinedPart head)
    {
        string fullName = CombinedPartNameMapper(head);
        var prefab = GetCombinedPart(fullName);

        var childLegs = GetBodyPart("head");
        Debug.Log(childLegs);
        Debug.Log(fullName + " " + prefab);
        var newLegs = Instantiate(prefab, childLegs.transform.position, childLegs.transform.rotation);
        newLegs.transform.parent = transform;
        newLegs.tag = "head";
        newLegs.GetComponent<Rigidbody>().isKinematic = true;
        newLegs.GetComponent<Rigidbody>().useGravity = false;
        Destroy(childLegs);
    }

    private GameObject GetBodyPart(string type)
    {
        var children = GetComponentsInChildren<Transform>();
        foreach(var child in children)
        {
            if (child.tag.ToLower() == type)
                return child.gameObject;
        }
        return null;
    }

}
