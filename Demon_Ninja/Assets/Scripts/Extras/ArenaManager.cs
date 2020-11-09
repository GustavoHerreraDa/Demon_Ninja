using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public Transform[] arenaSpawners;
    public GameObject[] enemiesToSpawn;
    public List<Enemy> arenaEnemies;


    public GameObject summonEffect;
    public GameObject arenaAward;

    public GameObject door;
    public GameObject wallObstacle;

    public bool isPlayerInArena;

    public float timeToSummon;
    public int countEnemyToSummon;
    private int currentEnemySummon;

    private bool canSummon = false;
    private float currentTimeToSummon;

    private int currentSpawner;
    private int maxPositionSpawner;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        currentSpawner = 0;
        maxPositionSpawner = arenaSpawners.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerInArena)
            return; 

        if (canSummon)
        {
            SpawnEnemy();
            canSummon = false;
        }
        else
        {
            currentTimeToSummon += Time.deltaTime;
            if (currentTimeToSummon >= timeToSummon)
            {
                canSummon = true;
                currentTimeToSummon = 0;
            }
        }
        EnemyCount();

    }

    private void SpawnEnemy()
    {
        if (currentEnemySummon == countEnemyToSummon)
            return;

        var effect = Instantiate(summonEffect, arenaSpawners[currentSpawner].position, arenaSpawners[currentSpawner].rotation);
        Destroy(effect.gameObject, 0.5f);

        var enemy = Instantiate(enemiesToSpawn[0]);
        enemy.transform.position = arenaSpawners[currentSpawner].position;
        enemy.GetComponent<Enemy>().arenaManager = this;

        currentSpawner++;
        currentEnemySummon++;

        arenaEnemies.Add(enemy.GetComponent<Enemy>());

        if (currentSpawner == maxPositionSpawner)
            currentSpawner = 0;
    }

    private void EnemyCount()
    {
        if (arenaEnemies.Count == 0)
        {
            if (wallObstacle != null)
                Destroy(wallObstacle);

            if (arenaAward != null)
                arenaAward.SetActive(true);

            if (door != null)
                door.SetActive(true);

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            isPlayerInArena = true;
        }
    }
}
