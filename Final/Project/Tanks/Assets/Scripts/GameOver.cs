using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] KeyCode restartKey;
    Text tanksKilledText;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        Transform tanksKilledTextObject = transform.Find("TanksKilled");
        if (tanksKilledTextObject != null) {
            tanksKilledText = tanksKilledTextObject.GetComponent<Text>();
            tanksKilledText.text = $"Tanks killed: {ScoreSaver.score}";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(restartKey)) {
            ScoreSaver.score = 0;
            SceneManager.LoadScene("Level1");
        }
    }

}
