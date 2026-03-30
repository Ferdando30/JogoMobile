using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPattern> patterns;
    public float maxTimer;


    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            SpawnNextPattern();
            timer = 0f;
        }
    }

    void SpawnNextPattern()
    {
        var pattern = patterns[Random.Range(0, patterns.Count)];

        StartCoroutine(ExecutePattern(pattern));
    }

    IEnumerator ExecutePattern(SpawnPattern pattern)
    {
        foreach (var instruction in pattern.Instructions)
        {
            if (instruction.delay > 0)
                yield return new WaitForSeconds(instruction.delay);

            Spawn(instruction);
        }
    }

    void Spawn(SpawnInstruction instruction)
    {
      Vector2 spawnPosition = new Vector2(
          transform.position.x + instruction.positionOffset.x,
          transform.position.y + instruction.positionOffset.y
      );

        ObjectPooler.Instance.SpawnFromPool(instruction.type, spawnPosition);
    }
}
