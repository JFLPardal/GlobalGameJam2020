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
            GameObject.Find("StartGame").GetComponent<SoundController>().PlaySound(SoundEvents.DROP);
        }
        else
        {
            transform.parent = otherTransform;
            GameObject.Find("StartGame").GetComponent<SoundController>().PlaySound(SoundEvents.PICKUP);
        }

        isPickedUp = !isPickedUp;
    }

}
