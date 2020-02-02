using UnityEngine;

public class PickAndDrop : Interactable
{
    bool isPickedUp = false;

    public bool IsPickedUp() { return isPickedUp; }
    public override void Interact(Transform otherTransform)
    {
        if (isPickedUp)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            transform.parent = otherTransform;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        isPickedUp = !isPickedUp;
    }

}
