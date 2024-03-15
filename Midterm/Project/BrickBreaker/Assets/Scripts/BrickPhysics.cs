using UnityEngine;

public class BrickPhysics : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;
//    GameObject _brickContainer;

    [SerializeField] int _hits;
    private Color[] colors = {new Color(1f, 1f, 1f),
                              new Color(0.61f, 0.88f, 0.96f),
                              new Color(0.22f, 0.76f, 0.92f)};
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
//       _brickContainer = GameObject.Find("Bricks");
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (_hits == 1) {
            Destroy(this.gameObject);
//            Debug.Log(_brickContainer.transform.childCount);
        }
        else {
            _hits -= 1;
            _sr.color = colors[_hits-1];
        }
    }
}
