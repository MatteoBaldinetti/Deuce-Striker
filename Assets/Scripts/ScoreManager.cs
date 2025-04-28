using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText; // Référence au composant Text UI
    public TextMeshPro scoreText1; // Référence au composant Text UI
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void addScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null && scoreText1 != null)
        {
            scoreText.text = score.ToString();
            scoreText1.text = score.ToString();
        }
    }
}
