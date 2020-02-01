using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTopEmpty : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
        if (collision.transform.tag.ToLower().Equals("body_part") 
            || collision.transform.tag.ToLower().Equals("animal_part")
            || collision.transform.tag.ToLower().Equals("combined_part"))
        {
            transform.parent.GetComponent<Box>().SetIsEmpty(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.ToLower().Equals("body_part")
            || collision.transform.tag.ToLower().Equals("animal_part")
            || collision.transform.tag.ToLower().Equals("combined_part"))
        {
            transform.parent.GetComponent<Box>().SetIsEmpty(true);
        }
    }

}
