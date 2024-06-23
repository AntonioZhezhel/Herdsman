using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float scoreMultiplier;
    private float score;

    public void SetTag(string tag)
    {
        if (tag == "Animal")
        {
            score += scoreMultiplier;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}