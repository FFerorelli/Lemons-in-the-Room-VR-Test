using UnityEngine;

public class Grabber : MonoBehaviour
{
    [Header("References")]
    // Reference to the camera of the First Person Controller
    [SerializeField] private Camera playerCamera;

    // A transform under your player/camera where you want to hold the object
    [SerializeField] private Transform holdPoint;

    [Header("Settings")]
    // How far you can reach to grab
    [SerializeField] private float grabRange = 3f;

    // The layer(s) that contain grabbable objects
    [SerializeField] private LayerMask grabLayer;

    private Rigidbody grabbedObject;  // The current object you're holding

    void Update()
    {
        // Check if player pressed E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If already holding an object, drop it
            if (grabbedObject != null)
            {
                DropObject();
            }
            else
            {
                // Otherwise, try to pick up an object
                TryGrabObject();
            }
        }
    }

    private void TryGrabObject()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Check if we hit a grabbable object within range
        if (Physics.Raycast(ray, out hit, grabRange, grabLayer))
        {
            // Optional: check if the object has a certain tag or a "Pickup" component
            // if (!hit.transform.CompareTag("Pickup")) return;

            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Grab it
                grabbedObject = rb;

                // Make it kinematic so it doesn't drop due to gravity or collisions
                grabbedObject.isKinematic = true;

                // Parent it to the holdPoint so it moves with the camera
                grabbedObject.transform.SetParent(holdPoint);

                // Reset position & rotation so it’s nicely in front of the player
                grabbedObject.transform.localPosition = Vector3.zero;
                grabbedObject.transform.localRotation = Quaternion.identity;
            }
        }
    }

    private void DropObject()
    {
        // Unparent
        grabbedObject.transform.SetParent(null);

        // Make it dynamic again
        grabbedObject.isKinematic = false;

        // Optionally, you can add a small force so it falls away from the player
        // grabbedObject.AddForce(playerCamera.transform.forward * 2f, ForceMode.Impulse);

        // Clear reference
        grabbedObject = null;
    }
}
