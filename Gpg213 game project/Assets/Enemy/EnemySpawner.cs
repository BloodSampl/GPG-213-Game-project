using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] GameObject enemy;
    [SerializeField] int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnEnemy();

    }
}
