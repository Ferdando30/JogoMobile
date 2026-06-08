using UnityEngine;

[System.Serializable]
public struct SpawnInstruction
{
    public enum SpawnableType
    {
        Coin,
        Obstacle,
        Bird,
        Ballon,
        Preda
    }

    [field: SerializeField]
    public SpawnableType type { get; private set; }

    [field: SerializeField]
    public Vector2 positionOffset { get; private set; }

    [field: SerializeField]
    public float delay { get; private set; }
}