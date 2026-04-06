using UnityEngine;

public class ScoreNumber : MonoBehaviour
{
    public float Score;
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
}
