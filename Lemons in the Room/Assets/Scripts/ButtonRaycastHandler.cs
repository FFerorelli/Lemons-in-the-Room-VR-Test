using UnityEngine;

public class ButtonRaycastHandler : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private Camera playerCamera;    // Your FPS camera
    [SerializeField] private float maxRayDistance = 5f;
    [SerializeField] private LayerMask buttonLayer;  // Layer that the button is on

    void Update()
    {
        // Left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from camera center forward
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxRayDistance, buttonLayer))
            {
                // Check if we hit a VRButtonHelper
                VRButtonHelper vrButton = hit.collider.GetComponent<VRButtonHelper>();
                if (vrButton != null)
                {
                    // "Press" it, which fires the same event as VR poke
                    vrButton.Press();
                }
            }
        }
    }
}