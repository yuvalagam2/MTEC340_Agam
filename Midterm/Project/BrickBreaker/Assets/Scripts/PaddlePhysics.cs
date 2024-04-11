using UnityEngine;
using System.Collections;

public class PaddlePhysics : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;

    [SerializeField] AudioClip _powerUp;
    AudioSource _source;

    [SerializeField] float _speed = 5.0f;
    int _direction;

    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = 0;

        if (Input.GetKey(_leftKey))
            _direction = -1;

        if (Input.GetKey(_rightKey))
            _direction = 1;

        if (Input.GetKey(_leftKey) && Input.GetKey(_rightKey))
            _direction = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
        PlaySample(_powerUp);

        if (other.CompareTag("PowerUp")) {
            //_sr.color = _sr.color == new Color(0f, 0f, 0f) ? new Color(1f, 1f, 1f) : new Color(0f, 0f, 0f);
            StopAllCoroutines();
            StartCoroutine(PaddleSize(10f, true));
        } else if (other.CompareTag("PowerDown")) {
            StopAllCoroutines();
            StartCoroutine(PaddleSize(10f, false));
        }
    }

    void FixedUpdate() {
        _rb.velocity = new Vector2(_speed * _direction, 0);
    }

    void IncreasePaddleSize() {
        transform.localScale = new Vector3(GameBehavior.Instance.bigPaddleSize, 0.2f, 1f);
    }

    void DecreasePaddleSize() {
        transform.localScale = new Vector3(GameBehavior.Instance.smallPaddleSize, 0.2f, 1f);
    }

    public void ResetPaddleSize() {
        transform.localScale = new Vector3(GameBehavior.Instance.paddleSize, 0.2f, 1f);
    }

    IEnumerator PaddleSize(float time, bool isGood) {

        float interval = 0.5f;

        if (isGood) {IncreasePaddleSize();}
        else {DecreasePaddleSize();}

        Color goodCol = Color.green;
        Color badCol = new Color(0.57f, 0.78f, 0.14f);

        while (time > 0f) {
            _sr.color = _sr.color == Color.white ? (isGood ? goodCol : badCol) : Color.white;
            time -= interval;

            if (time < 0.5f) {interval = 0.03f;}
            else if (time < 1f) {interval = 0.1f;}
            else if (time < 3f) {interval = 0.25f;}

            yield return new WaitForSeconds(interval);
        }

        ResetPaddleSize();
        _sr.color = Color.white;
    }

    void PlaySample(AudioClip clip) {
        GameBehavior.PlaySample(clip, _source);
    }
}
