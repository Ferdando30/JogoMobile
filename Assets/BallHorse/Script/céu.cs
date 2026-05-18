using UnityEngine;
using System.Collections;

public class céu : MonoBehaviour
{
    public float speed;
    public float postionInicial;
    public float postionFinal;

    public SpriteRenderer sprite;
    public SpriteRenderer nextSprite;
    public Sprite day;
    public Sprite sunset;
    public Sprite night;
    [SerializeField] Animator fade;
    [SerializeField] Background background;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * ScoreNumber.instance.moveMultiplier * Time.fixedDeltaTime);

        if (transform.position.x < postionFinal)
        {
            transform.Translate(Vector3.right * background.distance * 3);
//            transform.position = new Vector3(postionInicial + (transform.position.x - postionFinal), transform.position.y, transform.position.z);
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
