using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float highScore;
    public int carrots;
    public List<string> skins = new();
    public string selectedSkin;

    public GameData (TotalCarots totalCarots, HighScore highScoreClass, SkinSprite skinSprite)
    {
        carrots = totalCarots.CarotsTotal;
        highScore = highScoreClass.HighScoreCount;
        selectedSkin = SkinSprite.SelectedSkin;
        skins = skinSprite.skins;
}

}
