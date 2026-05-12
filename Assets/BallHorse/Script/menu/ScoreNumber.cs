using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreNumber : MonoBehaviour
{
    public float Score;
    public float moveMultiplier;
    public static ScoreNumber instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {

        if (Score < 99 || SceneManager.GetActiveScene().name == "Menu")
        {
            moveMultiplier = 1.0f;
        }
        else if (Score > 100) 
        {
            moveMultiplier = 6f;
        }
    }
}
