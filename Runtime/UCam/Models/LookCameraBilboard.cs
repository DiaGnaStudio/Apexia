using UnityEngine;

public class LookCameraBilboard : MonoBehaviour
{
    void Update()
    {
        if (UCamSystem.UCam.Instance != null)
        {
            // Get the direction from the object to the camera
            Vector3 lookDir = UCamSystem.UCam.Instance.transform.position - transform.position;

            // Make the object look at the camera but stay upright
            transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        }
    }
}
