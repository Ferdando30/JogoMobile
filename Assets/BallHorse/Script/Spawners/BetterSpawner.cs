using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPattern> patterns;
    public bool shot = false;


    private float lastSpawnX;

    void Update()
    {
        if (shot == false)
        {
            SpawnNextPattern();
            shot = true;
        }
    }

    void SpawnNextPattern()
    {
        var pattern = patterns[Random.Range(0, patterns.Count)];

        StartCoroutine(ExecutePattern(pattern, lastSpawnX));

        lastSpawnX += pattern.PatternLength;
    }

    IEnumerator ExecutePattern(SpawnPattern pattern, float baseX)
    {
        foreach (var instruction in pattern.Instructions)
        {
            if (instruction.delay > 0)
                yield return new WaitForSeconds(instruction.delay);

            Spawn(instruction, baseX);
        }
    }

    void Spawn(SpawnInstruction instruction, float baseX)
    {
      Vector2 spawnPosition = new Vector2(
          transform.position.x + baseX + instruction.positionOffset.x,
          transform.position.y + instruction.positionOffset.y
      );

        ObjectPooler.Instance.SpawnFromPool(instruction.type, spawnPosition);
    }
}
