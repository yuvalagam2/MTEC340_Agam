using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] KeyCode _pauseKey;
    bool paused = false;
    public void TogglePause() {
        Time.timeScale = paused ? 1f : 0f;
        paused = !paused;
    }

    void Update() {
        if (Input.GetKeyDown(_pauseKey)) {
            TogglePause();
        }
    }
}
