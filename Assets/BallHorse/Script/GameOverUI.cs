using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "FINAL SCORE: " + score;
    }

    public void ResetButton()
    {
        SceneManager.LoadScene("Ballhorse");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
