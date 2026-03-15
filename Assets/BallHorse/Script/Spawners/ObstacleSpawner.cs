using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public int obstacleCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleCount < 1)
        {
            objectPooler.SpawnFromPool("Obstacle", transform.position);
            obstacleCount++;
        }
        else
        {
            return;
        }
    }
}
