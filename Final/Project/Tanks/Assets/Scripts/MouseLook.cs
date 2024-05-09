using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        // Quaternion deltaRotation = Quaternion.AngleAxis(
        //     Input.GetAxis("Mouse X") * 9f, Vector3.up);
        // rb.rotation *= deltaRotation;

        transform.Rotate(
            0, Input.GetAxis("Mouse X") * 9f, 0);
    }
}
