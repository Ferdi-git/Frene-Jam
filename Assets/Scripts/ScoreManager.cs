using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        instance = this;
        score = 0;
        UpdateScore();
    }

    public void AddToScore(int toAdd)
    {
        score+= toAdd;
        UpdateScore();
    }

    public void UpdateScore()
    {
        textMeshPro.text = score.ToString();
    }
}
