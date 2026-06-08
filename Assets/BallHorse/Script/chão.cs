using UnityEngine;
using System.Collections;

public class chão : MonoBehaviour
{
    public float speed;
    public float postionInicialX;
    public float postionFinalX;
    public float postionFinalY;
    public float postionInicialY;
    public Pause pauseScript;

    public SpriteRenderer sprite;
    public SpriteRenderer nextSprite;
    public Sprite day;
    public Sprite sunset;
    public Sprite night;
    [SerializeField] Animator fade;
    [SerializeField] Background background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pauseScript.isPaused)
        {
            transform.Translate(Vector3.left * speed * ScoreNumber.instance.moveMultiplier * Time.deltaTime);

            if (transform.position.x < postionFinalX)// && transform.position.y > postionFinalY)
            {
                transform.position = new Vector3(postionInicialX, postionInicialY, transform.position.z);

            }
        }
    }

    public IEnumerator PlayFade()
    {
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(2.1f);
        CycleSprite();
        fade.SetTrigger("EndFade");
    }

    void CycleSprite()
    {
        if (sprite.sprite == day)
        {
            sprite.sprite = sunset;
            nextSprite.sprite = night;
        }
        else if (sprite.sprite == sunset)
        {
            sprite.sprite = night;
            nextSprite.sprite = day;
        }
        else if (sprite.sprite == night)
        {
            sprite.sprite = day;
            nextSprite.sprite = sunset;
        }
    }
}
