using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Vector3 _origin = new Vector3(0.0f, -3.8f, 0.0f);
    Rigidbody2D _rb;
    [SerializeField] float _speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("DWall")) {
            ResetBall();
        }
    }
    void ResetBall() {
        _rb.velocity = Vector2.zero;
        transform.position = _origin;
        Vector2 trajectory = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        Debug.Log(trajectory);
        _rb.AddForce(trajectory * _speed, ForceMode2D.Impulse);
       
       Debug.Log(_rb.velocity);
    }
}
