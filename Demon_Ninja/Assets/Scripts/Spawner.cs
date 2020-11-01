using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombieObject;
    public Transform[] spawnAreas;
    public ZombieEnemy zombieScript;
    private int number;
    void Start()
    {
        StartCoroutine(ZombieSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ZombieSpawn()
    {
        SpawnZombie();
        yield return new WaitForSeconds(0.3f);
    }

    private void SpawnZombie()
    {
         Instantiate(zombieObject);
        zombieObject.transform.position =new Vector3(spawnAreas[number].position.x,-1.5f,0);
        number = number + 1;
    }
}
