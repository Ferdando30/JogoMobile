using UnityEngine;
using TMPro;

public class TotalCarots : MonoBehaviour
{
    public int CarotsTotal;
    public static TotalCarots instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void CarrotUp()
    {
        CarotsTotal++;
    }

    public void LoadGame(GameData data)
    {
        if (data != null)
        {
            print(data.carrots);
            CarotsTotal = data.carrots;
        }
    }
}
