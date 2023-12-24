using System.Collections;
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
    [SerializeField] public CutsceneManager cutsceneManager;
    [HideInInspector]
    public int enemiesNumber = 0;
    bool waveEnd = false;

    public WaveManager waveManager;  

    
    void Start()
    {
        
        waveManager = FindObjectOfType<WaveManager>();
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemiesNumber++;
            enemiesText.text = "Enemies: " + enemiesNumber.ToString();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
        yield return new WaitForSeconds(timeBetweenWaves);

        
        waveManager.EndWave();

        pathC.wave++;
        waveText.text = "Wave: " + pathC.wave.ToString();
        pathC.pathFind = true;
        waveEnd = false;
    }

    
    void Update()
    {
        if (waveEnd == false && pathC.wave <= 3)
        {
            StartCoroutine(SpawnEnemy());
            waveEnd = true;
        }
    }
}
