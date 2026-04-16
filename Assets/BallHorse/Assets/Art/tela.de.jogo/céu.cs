using UnityEngine;

public class céu : MonoBehaviour
{
    public float speed;
    public float postionInicial;
    public float postionFinal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < postionFinal)
        {
            transform.position = new Vector3(postionInicial, transform.position.y, transform.position.z);

        }
    }
}
