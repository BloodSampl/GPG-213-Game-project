using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public CutsceneManager cutsceneManager;

    

    void EndWave()
    {
       
        cutsceneManager.OnWaveEnd();
    }
}
