using UnityEngine;
using System.Collections;
public class BallPhysics : MonoBehaviour
{
    Rigidbody2D _rb;

    AudioSource _source;
    [SerializeField] AudioClip _wallCollision;
    [SerializeField] AudioClip _paddleCollision;
    [SerializeField] AudioClip _brickCollision;
    [SerializeField] AudioClip _losePoint;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D other = collision.collider;
        switch (other.tag) {
            case "DWall":
                StartCoroutine(BottomCollision(1.5f));
                PlaySample(_losePoint);
                break;
            case "Paddle":
                Vector2 vel = new Vector2(
                    transform.position.x-other.transform.position.x,
                    other.transform.localScale.x/2
                ).normalized;
                _rb.velocity = vel*GameBehavior.Instance.ballSpeed;
                PlaySample(_paddleCollision);
                break;
            case "Brick":
                PlaySample(_brickCollision);
                break;
            default:
                PlaySample(_wallCollision);
                break;
        }
    }

    IEnumerator BottomCollision(float time) {
        SubtractLife();
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1f;
        
        GameBehavior.Instance.Reset();
    }

    void ResetBall() {
        GameBehavior.Instance.ResetBall();
    }

    void SubtractLife() {
        GameBehavior.Instance.UpdateLives();
    }

    void PlaySample(AudioClip clip) {
        GameBehavior.PlaySample(clip, _source);
    }

}