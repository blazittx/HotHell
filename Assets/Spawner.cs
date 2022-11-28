using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform EnemyGameObject;
    public int EnemyCount = 1;
    public int EnemiesToSpawn;
    GameObject spawnerContainer;

    void Start()
    {
        StartCoroutine(SpawnFireRate(2));
        //spawnerContainer = GameObject.FindWithTag("SpawnerContainer");
    }

    // Update is called once per frame
    void Update()
    {
       // spawnerContainer.GetComponent<SpawnerContainer>().CurrentDemonAmount = EnemyCount;
    }
    void InstantiateEnemy()
    {
        EnemyCount++;
        Transform Enemy;
        Enemy = Instantiate(EnemyGameObject, transform.position, Quaternion.identity);

    }
    IEnumerator SpawnFireRate(float SpawnRate)
    {
        while (EnemyCount < EnemiesToSpawn)
        {
            InstantiateEnemy();
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
