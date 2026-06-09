using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BetterSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPattern> patterns;
    [SerializeField] private List<SpawnPattern> powerups;
    public float maxTimer;
    public bool active = true;
    public List<GameObject> activeObjects;

    public static BetterSpawner instance;

    private float timer = 0f;
    private float powerupTimer = 30f;

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
            timer += Time.deltaTime * ScoreNumber.instance.moveMultiplier;
            powerupTimer -= Time.deltaTime;

            print(powerupTimer);

            if (timer >= maxTimer && powerupTimer > 0f)
            {
                SpawnNextPattern();
                timer = 0f;
            }
            else if (powerupTimer <= 0f)
            {
                print("Ding!");
                SpawnPowerup();
            }
        }
    }

    void SpawnNextPattern()
    {
        var pattern = patterns[Random.Range(0, patterns.Count)];

        StartCoroutine(ExecutePattern(pattern));
    }

    void SpawnPowerup()
    {
        var powerup = powerups[Random.Range(0, powerups.Count)];

        StartCoroutine(ExecutePattern(powerup));
    }

    IEnumerator ExecutePattern(SpawnPattern pattern)
    {
        foreach (var instruction in pattern.Instructions)
        {
            if (instruction.delay > 0)
                yield return new WaitForSeconds(instruction.delay / ScoreNumber.instance.moveMultiplier);

            Spawn(instruction);
            if (powerupTimer <= 0f)
            {
                powerupTimer = Random.Range(30, 45);
            }
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
    public void ActivateObjects()
    {
        foreach (GameObject objects in activeObjects)
        {
            Collectible collectibles = objects.GetComponent<Collectible>();
            if (collectibles != null)
            {
                collectibles.moving = true;
                continue;
            }

            Obstacle obstacles = objects.GetComponent<Obstacle>();
            if (obstacles != null)
            {
                obstacles.moving = true;
            }
        }
    }
}
