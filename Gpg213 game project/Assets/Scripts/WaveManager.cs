using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public CutsceneManager cutsceneManager;
    public EnemySpawner enemySpawner;
    

    public void EndWave()
    {
       
        cutsceneManager.OnWaveEnd();
    }
}
