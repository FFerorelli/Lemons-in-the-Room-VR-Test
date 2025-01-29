using UnityEngine;
using UnityEngine.XR; // Needed for XRSettings

public class VRModeSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject vrRig;
    [SerializeField] private GameObject pcRig;

    // Reference to the Camera component you want to activate in PC mode
    [SerializeField] private Camera pcCamera;

    void Start()
    {
        // Check if XR is enabled or if a VR headset is detected
        bool vrSupported = XRSettings.isDeviceActive; // or use OVRManager.isHmdPresent if using Oculus Integration
        Debug.Log($"VR Supported: {vrSupported}");

        if (vrSupported)
        {
            // VR mode
            vrRig.SetActive(true);
            pcRig.SetActive(false);

            // Disable the PC camera
            if (pcCamera != null)
            {
                pcCamera.enabled = false;
            }
        }
        else
        {
            // PC mode
            vrRig.SetActive(false);
            pcRig.SetActive(true);

            // Enable the PC camera
            if (pcCamera != null)
            {
                pcCamera.enabled = true;
            }
        }
    }
}
