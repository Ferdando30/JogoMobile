using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public static HighScore instance;
    public float HighScoreCount;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void SetHighScore()
    {
        if (HighScoreCount < ScoreNumber.instance.Score)
        {
            HighScoreCount = ScoreNumber.instance.Score + 1;
        }
    }

    public void LoadGame(GameData data)
    {
        if (data != null)
        {
            print(data.highScore);
            HighScoreCount = data.highScore;
        }
    }
}
