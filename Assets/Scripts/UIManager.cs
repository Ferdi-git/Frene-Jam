using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public static UIManager Instance;
    public GameObject lose;
    public TextMeshProUGUI Score;


    private void Start()
    {
        Instance = this;
    }

    public void Lose()
    {
        lose.SetActive(true);
        Score.text = ScoreManager.instance.score.ToString();
        Time.timeScale = 0;
    }

    public void UpdateSlider(float value)
    {
        slider.value = value;
    }


    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
