using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed;
    //public GameObject cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x > 17.38f)
        {
            transform.position = new Vector3(-17.43f, transform.position.y, transform.position.z);
            
        }
    }
}

