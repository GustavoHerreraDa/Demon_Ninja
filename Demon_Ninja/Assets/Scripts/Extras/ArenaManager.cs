using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public Transform[] arenaSpawners;
    public GameObject[] enemiesToSpawn;
    public List<Enemy> arenaEnemies;


    public GameObject summonEffect;
    public GameObject arenaAward;

    public float timeToSummon;
    public int countEnemyToSummon;

    private bool canSummon = false;
    private float currentTimeToSummon;

    private int currentSpawner;
    private int maxPositionSpawner;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawner = 0;
        maxPositionSpawner = arenaSpawners.Length;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void SpawnEnemy()
    {
        var effect = Instantiate(summonEffect, arenaSpawners[currentSpawner].position, arenaSpawners[currentSpawner].rotation);
        Destroy(effect.gameObject, 0.5f);

        var enemy = Instantiate(enemiesToSpawn[0]);
        enemy.transform.position = arenaSpawners[currentSpawner].position;
        currentSpawner++;

        if (currentSpawner == maxPositionSpawner)
            currentSpawner = 0;
    }
}
