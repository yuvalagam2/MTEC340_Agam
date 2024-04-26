using UnityEngine;

public class MouseLook : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        transform.Rotate(
                    0, Input.GetAxis("Mouse X") * 9f, 0);
    }
}
