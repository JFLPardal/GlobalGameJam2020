using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    protected PartDetails details;

    public virtual void DefineDetails(PartType _type)
    {
        if (details != null)
        {
            details.type = _type;
        }
    }

    public bool GetIsInMixer()
    {
        return details.isInMixer;
    }

    public void SetIsInMixer(bool value)
    {
        details.isInMixer = value;
    }

    public PartType GetType()
    {
        return details.type;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
