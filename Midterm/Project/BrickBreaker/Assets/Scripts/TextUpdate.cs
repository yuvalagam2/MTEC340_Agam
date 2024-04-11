using TMPro;
using UnityEngine;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField ]TextMeshProUGUI LivesText;
    
    public void UpdateScoreText(string n) {
        ScoreText.text = n;
    }
    public void UpdateLivesText(string n) {
        LivesText.text = n;
    }
}
