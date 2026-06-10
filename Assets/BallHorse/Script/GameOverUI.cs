using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameOverUI : MonoBehaviour
{

    public TMP_Text scoreText;

    public TotalCarots totalCarots;
    public HighScore highScore;
    public SkinSprite skinSprite;

    public ADPLAY addPlayScript;
    public Player playerScript;

    private void Start()
    {
        totalCarots = TotalCarots.instance;
        highScore = HighScore.instance;
        skinSprite = SkinSprite.instance;

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
        if (playerScript.TimesCanRevive >= 1)
        {
            addPlayScript.OnRewardedFinished = () =>
            {
                Debug.Log("Chamando UnDie depois do rewarded.");
                gameObject.SetActive(false);
                playerScript.UnDie();
            };

            addPlayScript.ShowRewardedAd();
        }
    }

    public void SaveGame()
    {
        SaveSystem.Save(totalCarots, highScore, skinSprite);
        print("Jogo salvo.");
    }
}
