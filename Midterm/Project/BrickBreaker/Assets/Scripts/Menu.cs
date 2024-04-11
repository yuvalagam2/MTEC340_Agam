using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AppHelper {
    #if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
    #endif
    public static void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }
}
public class Menu: MonoBehaviour {

    GameObject score;
    [SerializeField] KeyCode _quitKey;
    void Start() {
        if (SceneManager.GetActiveScene().name == "YouWin" || SceneManager.GetActiveScene().name == "GameOver") {
            score = transform.Find("Score").gameObject;
            score.GetComponent<TextMeshProUGUI>().text += GameBehavior.Instance.score.ToString();
        }
        
        
    }

    void Update() {
        if (Input.GetKeyDown(_quitKey)) {
            QuitGame();
        }
    }
    public void PlayGame() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        AppHelper.Quit();
    }

    
}