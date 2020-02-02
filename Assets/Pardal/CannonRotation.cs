using System.Collections;
using UnityEngine;

public class CannonRotation : Interactable
{
    [SerializeField] Transform CannonTip;
    [SerializeField] int shootingSpeed = 50;
    private bool isBeingUsed = false;
    private bool isHoldingPart = false;
    private GameObject partBeingHeld;
    private Collider partTrigger;

    private void Start()
    {
        foreach(var collider in GetComponents<BoxCollider>())
        {
            if(collider.isTrigger)
            {
                partTrigger = collider;
            }
        }
    }
    public override void Interact(Transform outsideTransform)
    {
        if (!isBeingUsed)
        {
            MountPlayer(outsideTransform);
        }
        else
        {
            ShootPart();
            UnmountPlayer(outsideTransform);
        }
        isBeingUsed = !isBeingUsed;
    }

    private void ShootPart()
    {
        if(partBeingHeld != null)
        {
            partBeingHeld.GetComponent<Rigidbody>().velocity = CannonTip.transform.forward * shootingSpeed;
            partTrigger.enabled = false;
            partBeingHeld.transform.parent = null;           
            StartCoroutine(ReactivatePartsTrigger());
        }
        partBeingHeld = null;
    }
    private IEnumerator ReactivatePartsTrigger()
    {
        yield return new WaitForSecondsRealtime(1f);
        partTrigger.enabled = true;
    }

    private void MountPlayer(Transform outsideTransform)
    {
        outsideTransform.GetComponent<PlayerMovement>().ChangeMoveAbility();
        transform.parent = outsideTransform;

    }
    private void UnmountPlayer(Transform outsideTransform)
    {
        outsideTransform.GetComponent<PlayerMovement>().ChangeMoveAbility();
        transform.parent = null;
    }
    protected void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Part>() != null && !other.GetComponent<Part>().IsPickedUp())
        {
            isHoldingPart = true;
            other.transform.parent.transform.parent = CannonTip;
            other.transform.parent.position = CannonTip.position;
            partBeingHeld = other.transform.parent.gameObject;
        }
    }
}
