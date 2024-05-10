using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bulletSpeed = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.tag);
        Destroy(gameObject);
    }
    
}
