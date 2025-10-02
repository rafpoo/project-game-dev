using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // box yang mau diikuti
    public Vector3 offset;     // jarak kamera dari box
    public float smoothSpeed = 0.125f; // kehalusan gerakan kamera

    void LateUpdate()
    {
        if (target != null)
        {
            // posisi target + offset
            Vector3 desiredPosition = target.position + offset;

            // bikin gerakan smooth
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // update posisi kamera
            transform.position = smoothedPosition;

            // kamera selalu ngeliatin target
            transform.LookAt(target);
        }
    }
}
