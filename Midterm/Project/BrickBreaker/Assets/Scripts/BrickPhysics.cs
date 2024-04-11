using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class BrickPhysics: MonoBehaviour
{
    SpriteRenderer _sr;

    [SerializeField] int _hits;
    Color[] colors = {new Color(1f, 1f, 1f),
                      new Color(0.61f, 0.88f, 0.96f),
                      new Color(0.22f, 0.76f, 0.92f)};
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (_hits == 1) {
            GameBehavior.Instance.UpdateScore(GameBehavior.Instance.brickDestroyPoints);
            SpawnPowerUp(transform);
            Destroy(this.gameObject);
        }
        else {
            GameBehavior.Instance.UpdateScore(GameBehavior.Instance.brickHitPoints);
            _hits -= 1;
            _sr.color = colors[_hits-1];
        }
    }

    static void SpawnPowerUp(Transform transform) {
        GameObject puPrefab = Resources.Load<GameObject>("PowerUp");
        GameObject pdPrefab = Resources.Load<GameObject>("PowerDown");
        GameObject power;


        if (Random.Range(0f, 1f) < 0.075) {
            power = Instantiate(puPrefab, transform.position, Quaternion.identity);
            Debug.Log(power);
        }
        else if (Random.Range(0f, 1f) < 0.025) {
            power = Instantiate(pdPrefab, transform.position, Quaternion.identity);
        }
    }
}
