using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed;
    public float postionInicial;
    public float postionFinal;
    
    public Sprite day;
    public Sprite sunset;
    public Sprite night;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * ScoreNumber.instance.moveMultiplier * Time.fixedDeltaTime);

        if (transform.position.x > postionFinal)
        {
            transform.position = new Vector3(postionInicial, transform.position.y, transform.position.z);
            
        }
    }
}

