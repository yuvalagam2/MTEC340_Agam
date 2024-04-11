using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D _rb ;
    [SerializeField] float _speed = 1.25f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Vector2 vel = new Vector2(0f, -_speed);
        _rb.velocity = vel;
    }
    void OnTriggerEnter2D(Collider2D other) {
        
        switch (other.tag) {
            case "DWall":
                Destroy(this.gameObject);
                break;
            case "Paddle":
                Destroy(this.gameObject);
                GameBehavior.Instance.UpdateScore(GameBehavior.Instance.collectPowerUpPoints);
                break;
        }
    }
}
