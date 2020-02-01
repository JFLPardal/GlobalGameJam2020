using UnityEngine;

public class PickAndDrop : Interactable
{
    bool isPickedUp = false;

    public override void Interact()
    {
        isPickedUp = !isPickedUp;
        if (isPickedUp)
            print("picked item");
        else
            print("dropped item");
    }
}
