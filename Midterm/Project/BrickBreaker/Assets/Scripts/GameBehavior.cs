using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    GameObject BrickContainer;

    public Vector3 ballOrigin = new Vector3(0f, -3.75f, 0f);

    public Vector3 paddleOrigin = new Vector3(0f, -4f, 0f);

    public float ballSpeed = 6.0f;

    public float paddleSize = 2f;

    public float bigPaddleSize = 3f;

    public float smallPaddleSize = 0.75f;


    public int score = 0;
    public int lives = 3;

    TextUpdate canvas;

    public int brickHitPoints = 10;

    public int brickDestroyPoints = 100;

    public int collectPowerUpPoints = 50;


    GameObject Ball;

    GameObject Paddle;


    void Awake()
    {
        BrickContainer = GameObject.Find("Bricks");

        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    void Start() {
        Ball = GameObject.Find("Ball");
        Paddle = GameObject.Find("Paddle");
        canvas = GameObject.Find("Canvas").GetComponent<TextUpdate>();
        Reset();
    }

    void Update()
    {
        if (BrickContainer.transform.childCount == 0) {

            SceneManager.LoadScene("YouWin");
        }

        if (lives == 0) {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Reset() {
        ResetBall();
        ResetPaddle();
        DestroyPowerUps();
    }

    public void ResetBall() {
        Rigidbody2D _rb = Ball.GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        Ball.transform.position = ballOrigin;
        Vector2 trajectory = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        _rb.AddForce(trajectory * ballSpeed, ForceMode2D.Impulse);
    }

    void ResetPaddle() {
        Paddle.transform.position = paddleOrigin;
        PaddlePhysics PaddleScript = Paddle.GetComponent<PaddlePhysics>();
        PaddleScript.StopAllCoroutines();
        PaddleScript.ResetPaddleSize();
        Paddle.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void DestroyPowerUps() {
        PowerUp[] powerUps = FindObjectsByType<PowerUp>(FindObjectsSortMode.None);
        foreach (PowerUp pu in powerUps) {Destroy(pu.gameObject);}
    }

    public void UpdateScore(int x) {
        score += x*lives;
        canvas.UpdateScoreText(score.ToString());
    }

    public void UpdateLives() {
        lives -= 1;
        canvas.UpdateLivesText(lives.ToString());
    }


    public static void PlaySample(AudioClip clip, AudioSource source) {
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);
    }
}
