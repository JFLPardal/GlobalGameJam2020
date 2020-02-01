﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Part : MonoBehaviour
{
    protected PartDetails details;
    protected PickAndDrop pickAndDrop;

    private void Awake()
    {
        pickAndDrop = GetComponentInParent<PickAndDrop>();
        Assert.IsNotNull(pickAndDrop, "pickAndDrop not found for object");
    }
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

    public bool IsPickedUp()
    {
        return pickAndDrop.IsPickedUp();
    }
    
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
