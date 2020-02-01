using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    BodyPartDetails details;

    void Start()
    {
        details = new BodyPartDetails();
        details.type = BodyPartType.ARMS;
        details.inMixer = false;
    }

    public void defineDetails(BodyPartType _type)
    {
        if (details != null)
        {
            details.type = _type;
        }
    }

    public bool isInMixer()
    {
        return details.inMixer;
    }

    public void setInMixer(bool value)
    {
        details.inMixer = value;
    }

    public BodyPartType type()
    {
        return details.type;
    }

    public void destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
