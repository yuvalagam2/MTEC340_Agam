using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bulletSpeed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Debug.Log(other.collider.tag);
    }
    
}
