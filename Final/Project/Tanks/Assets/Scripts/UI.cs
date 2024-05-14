using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;
    GameObject canvas;
    Text HPText;
    Text tanksKilledText;

    
    void Awake()
    {
        if (Instance != null && Instance != this) {
            Debug.Log("Multiple UI managers found.");
            Destroy(this);
        } else {
            Instance = this;
        }

        canvas = GameObject.Find("Canvas");
        HPText = canvas.transform.Find("HP").GetComponent<Text>();    
        tanksKilledText = canvas.transform.Find("TanksKilled").GetComponent<Text>();  
    }


    public void UpdateHPText(int hp) {
        HPText.text = $"HP: {hp}";
    }

    public void UpdateTanksKilledText(int tanksKilled) {
        tanksKilledText.text = $"Tanks killed: {tanksKilled}";
    }
}
