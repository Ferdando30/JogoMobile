using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] skies;
    public float distance;

    private void Start()
    {
        distance = skies[1].transform.position.x - skies[0].transform.position.x;
    }
}
