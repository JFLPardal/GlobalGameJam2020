using System.Collections;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    private BoxCollider trigger;
    private bool isInteracting = false;
    private bool canInteract = true;
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
    }

    private void OnTriggerStay(Collider other)
    {
        if (isInteracting && canInteract && other.CompareTag("Interactable"))
        {
            other.GetComponent<Interactable>().Interact(transform);
            canInteract = false;
            StartCoroutine(EnableInteraction());
        }
    }
    private IEnumerator EnableInteraction()
    {
        yield return new WaitForSecondsRealtime(1);
        canInteract = true;
    }
}
