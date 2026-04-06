using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    //public float Score;
    public TextMeshProUGUI ScoreText;
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
