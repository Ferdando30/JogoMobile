using UnityEngine;
using UnityEngine.UI;

public class SelectBtnBugFix : MonoBehaviour
{
    SkinSprite skinSpriteScript;
    public Button SelectButton;
    public string qualSkin;

    private void Awake()
    {
        skinSpriteScript = GameObject.FindGameObjectWithTag("Don'tDestroyManager").GetComponent<SkinSprite>();
        if(qualSkin == "Unicornio")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectUni);
        }

        else if(qualSkin == "Padrao")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectPadrao);
        }

        else if (qualSkin == "Chiclete")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectChic);
        }

        else if (qualSkin == "Real")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectReal);
        }

        else if (qualSkin == "Alien")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectAlien);
        }

        else if (qualSkin == "Candy")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectSceneCandy);
        }

        else if (qualSkin == "Lua")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectSceneMoon);
        }

        else if (qualSkin == "Monte")
        {
            SelectButton.onClick.AddListener(skinSpriteScript.SelectScenePadrao);
        }
    }
}
