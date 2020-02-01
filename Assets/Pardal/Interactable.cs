using UnityEngine;
public abstract class Interactable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "Interactable";
    }
    public abstract void Interact();
}
