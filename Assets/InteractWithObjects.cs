using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    private BoxCollider trigger;
    private bool isInteracting = false;
    PlayerControls controls;

    private void Awake()
    { 
        foreach(var collider in GetComponentsInChildren<BoxCollider>())
        {
            if (collider.isTrigger) trigger = collider;
        }
        if (trigger == null) Debug.LogError("Character doesn't hava an interaction trigger");

        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => OnInteract();
    }

    void OnInteract()
    {
        isInteracting = !isInteracting;
        print("clicked");
    }

    private void OnTriggerStay(Collider other)
    {
        print(isInteracting);
        if (isInteracting && other.CompareTag("Interactable"))
        {
            other.GetComponent<Interactable>().Interact();
            other.transform.parent = transform;
            // child other to this player
        }
    }
}
