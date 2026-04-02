using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public float Score;
    public TextMeshProUGUI ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = $"Score: {Mathf.Floor(Score)}";
    }
}
