using System.Collections;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    EnemyState state = EnemyState.Patrol;
    EnemyMoveState moveState = EnemyMoveState.Cruise;
    [SerializeField] float cruiseSpeed = 8f;
    [SerializeField] float pursueSpeed = 12f;
    [SerializeField] float rotSpeed = 75f;
    [SerializeField] float pursueRotSpeed = 135f;
    [SerializeField] float wallDistance = 10f;
    [SerializeField] float stopDistance = 4f;
    bool isTriggered = false;
    //GameObject turret;
    LayerMask turnLayer;
    LayerMask playerLayer;
    Rigidbody rb;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turnLayer = LayerMask.GetMask("Environment", "Tanks");
    //    turret = transform.Find("Turret").gameObject;
        player = GameObject.Find("PlayerTank");
        playerLayer = LayerMask.GetMask("PlayerTank");
    }
    void Update()
    {

        if (state == EnemyState.Patrol) {Patrol();}
        else {Pursue();}
    }
    void OnCollisionEnter(Collision collision)
    {
        /////////////// Particle system?
        if (collision.collider.gameObject.CompareTag("Projectile")) {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == 8) {
        //    Debug.Log("Trigger entered by player.\nStopping all coroutines and setting tracking state to 'Pursue'.");
            Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit hit); {
                if (hit.transform.gameObject.layer == 8) {
                    StopAllCoroutines();
                    state = EnemyState.Pursue;
                }
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        if (other.gameObject.layer == 8) {
            StopAllCoroutines();
        //    Debug.Log("Trigger exited by player.\nSetting tracking state to 'Patrol' and setting movement state to 'Cruise'.");
            state = EnemyState.Patrol;
            moveState = EnemyMoveState.Cruise;
        }        
    }

    void Patrol() {
        if (moveState == EnemyMoveState.Cruise){
            if (Physics.Raycast(transform.position,
            transform.forward,
            wallDistance,
            turnLayer)) {
            //    Debug.Log("Environment layer detected within raycast.\nChanging enemy movement state from 'Cruise' to 'Turn'.\nStarting coroutine 'Turn'.");
                rb.velocity = Vector3.zero;
                moveState = EnemyMoveState.Turn;
                StartCoroutine(
                    Turn((Random.Range(0, 2) == 1 ? 1 : -1) *
                    (90f+Random.Range(0f, 30f)),
                    rotSpeed)
                );
            }
            else {Cruise(transform.forward * cruiseSpeed);}
        }
        /*No-man's land. Tank gets stuck if (state = Patrol and moveState = Turn).*/
        // else {}
        
    }

    void Pursue() {

        Vector3 direction = (player.transform.position - transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit)) {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
            if (hit.collider.gameObject.layer != 8) {
                Debug.Log("Player is not in line of sight. Switching to patrol mode.");
                state = EnemyState.Patrol;
                moveState = EnemyMoveState.Cruise;
                return;
            }
        }

        transform.rotation = Quaternion.LookRotation(direction);
        if (Vector3.Distance(transform.position, player.transform.position) < stopDistance) {
            rb.velocity = Vector3.zero;
        } else {
            Cruise(transform.forward * pursueSpeed);
        }
    }

    void Cruise(Vector3 velocity) {
        rb.velocity = velocity;
    }

    IEnumerator Turn(float angle, float rotationSpeed) {
        float deltaRotation = 0f;
        
        while (deltaRotation < Mathf.Abs(angle)) {            
            transform.Rotate(0, (angle < 0 ? -1 : 1) * rotationSpeed * Time.deltaTime, 0);
            deltaRotation += rotationSpeed * Time.deltaTime;
            yield return null;
        }
    //    Debug.Log("Done turning.");
        moveState = EnemyMoveState.Cruise;
    //    Debug.Log("EnemyMoveState set to 'Cruise'. Coroutine 'Turn' done.");
    }
}
