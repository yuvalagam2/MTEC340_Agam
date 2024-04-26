using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    void OnTriggerEnter()
    {
        Destroy(this.gameObject);
    }

}
