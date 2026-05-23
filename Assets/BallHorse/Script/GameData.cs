using UnityEngine;

public class GameData
{
    public float highScore;
    public int carrots;
    public string[] skins;

    public GameData (TotalCarots totalCarots, HighScore highScoreClass)
    {
        carrots = totalCarots.CarotsTotal;
        highScore = highScoreClass.HighScoreCount;
    }

}
