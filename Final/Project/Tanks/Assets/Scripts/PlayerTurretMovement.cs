using System.Collections;
using UnityEngine;

public class PlayerTurretMovement : MonoBehaviour
{
    [SerializeField] float turretRotSpeed = 45f;
    [SerializeField] float turretMaxYRot = 45f;
    [SerializeField] float shootingInterval = 1f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] KeyCode shootButton;
    bool isShooting = false;
    
    void Update()
    {
        Aim();
        if (Input.GetKeyDown(shootButton)) {
            StartCoroutine(Shoot(shootingInterval));
        }
    }

    void Aim() {
        float yRot = transform.localEulerAngles.y;

        yRot =
            (yRot >= 180) ?
            Mathf.Clamp(yRot, 360-turretMaxYRot, 360f) :
            Mathf.Clamp(yRot, 0, turretMaxYRot);

        // yRot = Mathf.Clamp(yRot, -turretMaxYRot, turretMaxYRot);
        // This code did not work, because Transform.eulerAngles returns between
        // [0, 360) for each element, instead of negative values.

        float direction = (Input.GetMouseButton(0) ? -1f : 0f) + (Input.GetMouseButton(1) ? 1f : 0f);
        yRot += direction*turretRotSpeed*Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, yRot, 0);
    }

    IEnumerator Shoot(float waitInterval) {
        if (!isShooting) {
            isShooting = true;

            GameObject bullet = Instantiate(
                bulletPrefab,
                transform.Find("Cylinder (1)").transform.position,
                transform.rotation);
            yield return new WaitForSeconds(waitInterval);
            isShooting = false;
        } else {
            yield return null;
        }
    }
}
