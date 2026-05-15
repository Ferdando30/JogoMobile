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

    private void Start()
    {
        //StartCoroutine(PlayFade());
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * ScoreNumber.instance.moveMultiplier * Time.deltaTime);

        if (transform.position.x < postionFinal)
        {
            transform.position = new Vector3(postionInicial, transform.position.y, transform.position.z);

        }
    }

    public IEnumerator PlayFade()
    {
        fade.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        CycleSprite();
        fade.SetTrigger("EndFade");
        print("Bup!");
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
