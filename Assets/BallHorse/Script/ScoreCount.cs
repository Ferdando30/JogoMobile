using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    //public float Score;
    public TextMeshProUGUI ScoreText;
    public bool gameOver = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!gameOver)
        {
            ScoreNumber.instance.Score += Time.deltaTime * 10;
            HighScore.instance.SetHighScore();
            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        ScoreText.text = $"Score: {Mathf.Floor(ScoreNumber.instance.Score)}";
    }
}
