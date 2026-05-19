using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    private SpriteRenderer PlayerRenderer;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        PlayerRenderer = GetComponent<SpriteRenderer>();
        PlayerRenderer.sprite = SkinSprite.SkinHolder;
        anim = GetComponent<Animator>();
        if(SkinSprite.isUni == true)
        {
            anim.Play("UniClip");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
