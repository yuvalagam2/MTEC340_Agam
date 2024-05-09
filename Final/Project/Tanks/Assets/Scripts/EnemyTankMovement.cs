using System.Collections;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    EnemyState enemyState = EnemyState.Cruise;
    [SerializeField] float cruiseSpeed = 5f;
    [SerializeField] float pursueSpeed = 10f;
    [SerializeField] float rotSpeed = 75f;
    [SerializeField] float wallDistance = 2f;
    LayerMask layersToHit;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        layersToHit = LayerMask.GetMask("Environment");
    }
    void Update() {
        Patrol();
    }
    void OnTriggerEnter()
    {
        /////////////// Particle system?
        Destroy(gameObject);
    }

    void Patrol() {
        if (enemyState == EnemyState.Cruise){
            if (Physics.Raycast(transform.position,
            transform.forward,
            wallDistance,
            layersToHit)) {
                rb.velocity = Vector3.zero;
                enemyState = EnemyState.Turn;
                StartCoroutine(Turn());
            }
            else {rb.velocity = transform.forward * cruiseSpeed;}
        }
        
    }
    IEnumerator Turn() {
        float angle = 90f+Random.Range(0f, 30f);
        // Debug.Log(angle);
        float deltaRotation = 0f;
        int direction = Random.Range(0, 2) == 1 ? 1 : -1;
        
        while (deltaRotation < angle) {            
            transform.Rotate(0, direction * rotSpeed * Time.deltaTime, 0);
            deltaRotation += rotSpeed * Time.deltaTime;
            yield return null;
        }
        enemyState = EnemyState.Cruise;
    }
}
