using UnityEngine;
using System.Collections;

public class céu : MonoBehaviour
{
    public float speed;
    public float postionInicial;
    public float postionFinal;

    public SpriteRenderer sprite;
    public SpriteRenderer nextSprite;
    public SpriteRenderer nextScenerySprite;
    public Sprite day;
    public Sprite sunset;
    public Sprite night;
    public Sprite sceneryCandy;
    public Sprite sceneryMoon;
    [SerializeField] Animator fade;
    [SerializeField] Background background;


    public SkinSprite skinSprite;
    public Pause pauseScript;

    public string currentScenery = "Padrão";

    private bool cancelCall = false;

    public void Start()
    {
        SelectScenery();
        if (sprite.sprite == sceneryCandy || sprite.sprite == sceneryMoon)
        {
            nextSprite.gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if (!pauseScript.isPaused)
        {
            transform.Translate(Vector3.left * speed * ScoreNumber.instance.moveMultiplier * Time.fixedDeltaTime);

            if (transform.position.x < postionFinal)
            {
                transform.Translate(Vector3.right * background.distance * 3);
                //            transform.position = new Vector3(postionInicial + (transform.position.x - postionFinal), transform.position.y, transform.position.z);
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

//    public IEnumerator FadeScenery()
//    {
//        nextScenerySprite.gameObject.SetActive(true);
//        CycleScenery();
//        if (cancelCall)
//        {
//            cancelCall = false;
//            nextScenerySprite.gameObject.SetActive(false);
//            yield break;
//        }
//        fade.SetTrigger("Fade");
//        yield return new WaitForSeconds(2.1f);
//        if (currentScenery == "Padrão")
//        {
//            sprite.sprite = day;
//        }
//        else if (currentScenery == "Doce")
//        {
//            sprite.sprite = sceneryCandy;
//        }
//        else if (currentScenery == "Lua")
//        {
//            sprite.sprite = sceneryMoon;
//        }
//        fade.SetTrigger("EndFade");
//        nextScenerySprite.gameObject.SetActive(false);
//    }

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

    void SelectScenery()
    {
        if (SkinSprite.SelectedScenery != "Padrão")
        {
            if (SkinSprite.SelectedScenery == "Lua")
            {
                sprite.sprite = sceneryMoon;
            }
            if (SkinSprite.SelectedScenery == "Doce")
            {
                sprite.sprite = sceneryCandy;
            }
        }
    }

//    void CycleScenery()
//    {
//        string nextScenery = skinSprite.sceneries[Random.Range(0, skinSprite.sceneries.Count)];
//        if (nextScenery == currentScenery && skinSprite.sceneries.Count > 1)
//        {
//            CycleScenery();
//            return;
//        }
//        else if (skinSprite.sceneries.Count == 1)
//        {
//            cancelCall = true;
//            return;
//        }
//        
//        currentScenery = nextScenery;
//
//        if (currentScenery == "Padrão")
//        {
//            nextScenerySprite.sprite = day;
//        }
//        else if (currentScenery == "Doce")
//        {
//            nextScenerySprite.sprite = sceneryCandy;
//        }
//        else if (currentScenery == "Lua")
//        {
//            nextScenerySprite.sprite = sceneryMoon;
//        }
//    }
}
