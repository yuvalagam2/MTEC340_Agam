using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    Transform tr;
    [SerializeField] float speed = 5f;
    

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z).normalized;
        tr.Translate(movement*speed*Time.deltaTime);
    }
}
