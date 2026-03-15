using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public int coinCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCount < 1)
        {
            objectPooler.SpawnFromPool("Coin", transform.position);
            coinCount++;
        }
        else
        {
            return;
        }
    }
}
