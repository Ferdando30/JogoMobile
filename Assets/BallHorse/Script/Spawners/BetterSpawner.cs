using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BetterSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPattern> patterns;
    public float maxTimer;
    public bool active = true;
    public List<GameObject> activeObjects;

    public static BetterSpawner instance;

    private float timer = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                SpawnNextPattern();
                timer = 0f;
            }
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

        GameObject spawnedObject = ObjectPooler.Instance.SpawnFromPool(instruction.type, spawnPosition);
        activeObjects.Add(spawnedObject);
    }

    public void DeactivateObjects()
    {
        foreach (GameObject objects in activeObjects)
        {
            Collectible collectibles = objects.GetComponent<Collectible>();
            if (collectibles != null)
            {
                collectibles.moving = false;
                continue;
            }

            Obstacle obstacles = objects.GetComponent<Obstacle>();
            if (obstacles != null)
            {
                obstacles.moving = false;
            }
        }
    }
}
