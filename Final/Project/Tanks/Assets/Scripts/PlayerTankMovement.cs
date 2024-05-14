using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    [SerializeField] int hp = 5;
    public int HP {
        get => hp;
        set {hp = value;}
    }
    [SerializeField] float speed = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.CompareTag("EnemyProjectile")) {
            HP -= 1;
            Game.Instance.AssessPlayerDamage();
        }
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
