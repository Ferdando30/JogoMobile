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

    private void Start()
    {
        CarotsTotal = 0;
    }

    public void CarrotUp()
    {
        CarotsTotal++;
    }
}
