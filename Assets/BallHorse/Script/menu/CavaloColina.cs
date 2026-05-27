using UnityEngine;

public class CavaloColina : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        anim = GetComponent<Animator>();
        if (SkinSprite.isUni == true && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
             anim.Play("cavaloUnicornionacolina_Clip");
           // transform.position = new Vector3(-5.25f, -0.6936363f, 0);
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == true && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("cavaloETnacolina_Clip");
           // transform.position = new Vector3(-6.01f, -0.78f, 0);
           
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == true && SkinSprite.isChiclete == false && SkinSprite.isReal == false)
        {
            anim.Play("cavalonacolinaanimacaoidol_Clip");
           // transform.position = new Vector3(-0.87f, -5.03f, 0);
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == true && SkinSprite.isReal == false)
        {
            anim.Play("cavaloChicletaonacolina_Clip");
          //  transform.position = new Vector3(-5.2f, -0.74f, 0);
        }
        if (SkinSprite.isUni == false && SkinSprite.isAlien == false && SkinSprite.isPadrao == false && SkinSprite.isChiclete == false && SkinSprite.isReal == true)
        {
            anim.Play("cavaloRealistanacolina_Clip");
           // transform.position = new Vector3(-5.41f, -0.58f, 0);
        }
    }


}
