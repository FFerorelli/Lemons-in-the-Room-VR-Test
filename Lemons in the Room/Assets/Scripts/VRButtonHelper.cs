using Oculus.Interaction;
using UnityEngine;

// Simple helper script to let you press this button from code.
public class VRButtonHelper : MonoBehaviour
{
    [SerializeField] private InteractableUnityEventWrapper eventWrapper;

    // This method calls the same event that a VR "poke select" would trigger
    public void Press()
    {
        if (eventWrapper != null)
        {
            // The eventWrapper has "When Select()" that you set in the Inspector
            eventWrapper.WhenSelect.Invoke();
        }
        else
        {
            Debug.LogWarning("No InteractableUnityEventWrapper assigned!");
        }
    }
}
