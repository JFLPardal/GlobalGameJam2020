using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Extensions;

public static class OrderCompletion
{
    public static bool IsOrderComplete(Body body, Order order)
    {
        foreach(var pair in body.currentParts)
        {
            if (!order.expectedParts.ContainsPair(pair))
            {
                return false;
            }
        }
        return true;
    }
    
}
