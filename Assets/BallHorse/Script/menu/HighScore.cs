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

    void Start()
    {
        HighScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScore()
    {
        if (HighScoreCount < ScoreNumber.instance.Score)
        {
            HighScoreCount++;
        }
    }
}
