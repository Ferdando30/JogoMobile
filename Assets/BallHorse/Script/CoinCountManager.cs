using UnityEngine;

public class CoinCountManager : MonoBehaviour
{
    public int carotCount = 0;
    public static CoinCountManager instance;
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
