using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z).normalized;
        Vector3 worldMovement = transform.TransformDirection(movement);
        rb.velocity = speed * worldMovement;
    }
}
