using UnityEngine;

public class PickAndDrop : Interactable
{
    bool isPickedUp = false;

    public bool IsPickedUp() { return isPickedUp; }
    public override void Interact(Transform otherTransform)
    {
        if (isPickedUp)
            transform.parent = null;
        else
            transform.parent = otherTransform;
        isPickedUp = !isPickedUp;
    }

}
