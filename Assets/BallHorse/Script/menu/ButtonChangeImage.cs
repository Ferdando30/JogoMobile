using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeImage : MonoBehaviour
{
    public Button PadraoSelect;
    public Button ChicSlect;
    public Button AlienSelect;
    public Button UniSelect;
    public Button RealSelect;

    public Sprite noSelect;
    public Sprite yesSelect;

    // Update is called once per frame
    void Update()
    {
        if (SkinSprite.SelectedSkin == "Uni")
        {
            UniSelect.image.sprite = yesSelect;
            PadraoSelect.image.sprite = noSelect;
            ChicSlect.image.sprite = noSelect;
            AlienSelect.image.sprite = noSelect;
            RealSelect.image.sprite = noSelect;
        }
        else if (SkinSprite.SelectedSkin == "Alien")
        {
            UniSelect.image.sprite = noSelect;
            PadraoSelect.image.sprite = noSelect;
            ChicSlect.image.sprite = noSelect;
            AlienSelect.image.sprite = yesSelect;
            RealSelect.image.sprite = noSelect;
        }
        else if (SkinSprite.SelectedSkin == "Padrao")
        {
            UniSelect.image.sprite = noSelect;
            PadraoSelect.image.sprite = yesSelect;
            ChicSlect.image.sprite = noSelect;
            AlienSelect.image.sprite = noSelect;
            RealSelect.image.sprite = noSelect;
        }
        else if (SkinSprite.SelectedSkin == "Chic")
        {
            UniSelect.image.sprite = noSelect;
            PadraoSelect.image.sprite = noSelect;
            ChicSlect.image.sprite = yesSelect;
            AlienSelect.image.sprite = noSelect;
            RealSelect.image.sprite = noSelect;
        }
        else if (SkinSprite.SelectedSkin == "Real")
        {
            UniSelect.image.sprite = noSelect;
            PadraoSelect.image.sprite = noSelect;
            ChicSlect.image.sprite = noSelect;
            AlienSelect.image.sprite = noSelect;
            RealSelect.image.sprite = yesSelect;
        }
    }
}
