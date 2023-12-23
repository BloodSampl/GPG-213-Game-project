using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] PathFindingCalculations pathC;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] public TextMeshProUGUI enemiesText;
    
    [HideInInspector]
    public int  enemiesNumber = 0;
    bool waveEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy,transform.position,Quaternion.identity);
            enemiesNumber++;
            enemiesText.text = "Enemies: " + enemiesNumber.ToString();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
        yield return new WaitForSeconds(timeBetweenWaves); 
        
        pathC.wave++;
        waveText.text = "Wave: " + pathC.wave.ToString();
        pathC.pathFind = true;
        waveEnd = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waveEnd == false)
        {
            StartCoroutine(SpawnEnemy());
            waveEnd = true;
            
        }

    }
}
