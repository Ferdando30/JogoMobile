using UnityEngine;
using TMPro;

public class TotalCarots : MonoBehaviour
{
    public int CarotsTotal;
    public static TotalCarots instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarrotUp()
    {
        CarotsTotal++;
    }
}
