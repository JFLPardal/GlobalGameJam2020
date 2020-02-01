using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    protected PartDetails details;

    public virtual void DefineDetails()
    {
    }

    public bool GetIsInMixer()
    {
        return details.isInMixer;
    }

    public void SetIsInMixer(bool value)
    {
        details.isInMixer = value;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
