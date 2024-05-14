using System.Collections;
using UnityEngine;

public class EnemyTurretMovement : MonoBehaviour
{   
    Transform mouth;
    [SerializeField] GameObject bulletPrefab;
    EnemyTankMovement enemyTankMovementScript;
    bool isShooting = false;
    [SerializeField] float shootInterval;

    void Start()
    {
        mouth = transform.Find("Cylinder (1)");
        enemyTankMovementScript = GetComponentInParent<EnemyTankMovement>();
    }
    void LateUpdate()
    {
        if (enemyTankMovementScript.state == EnemyState.Pursue && !isShooting) {
            StartCoroutine(Shoot(shootInterval));
        }
    }

    IEnumerator Shoot(float interval) {
        isShooting = true;
        GameObject bullet = Instantiate(
            bulletPrefab,
            mouth.position,
            transform.rotation
        );
        yield return new WaitForSeconds(interval);
        isShooting = false;
        
    }
}
