using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Spawn Pattern", menuName = "Scriptable Objects/Spawn Pattern")]
public class SpawnPattern : ScriptableObject
{
    [SerializeField]
    private List<SpawnInstruction> instructions;

    [SerializeField]
    private float patternLength = 10f;

    public List<SpawnInstruction> Instructions => instructions;
    public float PatternLength => patternLength;
}