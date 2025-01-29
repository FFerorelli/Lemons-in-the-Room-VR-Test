using UnityEngine;
using UnityEngine.XR;

public class VRModeSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject vrRig;
    [SerializeField] private GameObject pcRig;

    void Start()
    {
        // Check if XR is enabled or if a VR headset is detected
        bool vrSupported = XRSettings.isDeviceActive; // or use OVRManager.isHmdPresent if using Oculus Integration
        Debug.Log(vrSupported +  "--------------------------------");

        if (vrSupported)
        {
            // VR mode
            vrRig.SetActive(true);
            pcRig.SetActive(false);
        }
        else
        {
            // PC mode
            vrRig.SetActive(false);
            pcRig.SetActive(true);
        }
    }
}
