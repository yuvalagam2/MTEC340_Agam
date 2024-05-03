using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
            Debug.LogError("More than one audio manager found in scene.");
        }
        else {Instance = this;}
    }

    public void PlayOneShot(EventReference sound, Vector3 pos) {
        RuntimeManager.PlayOneShot(sound, pos);
    }

    public EventInstance CreateEventInstance(EventReference eventReference) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject) {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        return emitter;
    }
}
