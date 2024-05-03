using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] EventReference coinCollectedSound;
    [SerializeField] EventReference coinAuraSound;
    private StudioEventEmitter emitter;

    void Start()
    {
        emitter = AudioManager.Instance.InitializeEventEmitter(coinAuraSound, gameObject);
        emitter.Play();
    }
    void OnTriggerEnter2D()
    {
        AudioManager.Instance.PlayOneShot(coinCollectedSound, transform.position);
        Destroy(transform.parent.gameObject);
        emitter.Stop();
    }
}
