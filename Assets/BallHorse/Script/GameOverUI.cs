using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameOverUI : MonoBehaviour
{

    public TMP_Text scoreText;

    public TotalCarots totalCarots;
    public HighScore highScore;

    public ADPLAY addPlayScript;
    public Player playerScript;

    private void Start()
    {
        totalCarots = TotalCarots.instance;
        highScore = HighScore.instance;
        gameObject.SetActive(false);
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "FINAL SCORE: " + score;
    }

    public void ResetButton()
    {
        ScoreNumber.instance.ResetValues();
        SceneManager.LoadScene("Ballhorse");
    }

    public void MenuButton()
    {
        ScoreNumber.instance.ResetValues();
        SceneManager.LoadScene("Menu");
    }

    public void Reviver()
    {
        gameObject.SetActive(false);
        
    }

    public void SaveGame()
    {
        SaveSystem.Save(totalCarots, highScore);
        print("Jogo salvo.");
    }
}
