using UnityEngine;

public class chão : MonoBehaviour
{
    public float speed;
    public float postionInicialX;
    public float postionFinalX;
    public float postionFinalY;
    public float postionInicialY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < postionFinalX && transform.position.y > postionFinalY)
        {
            transform.position = new Vector3(postionInicialX, postionInicialY, transform.position.z);

        }

    }
}
