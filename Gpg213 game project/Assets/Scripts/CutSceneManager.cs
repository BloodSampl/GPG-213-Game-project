using aitcHUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public string[] cutsceneSceneNames = {"CutScene2", "CutScene3", "CutScene4" };
    private int currentCutsceneIndex = 0;

   
    public void OnWaveEnd()
    {
        if (currentCutsceneIndex < cutsceneSceneNames.Length)
        {
            SceneManager.LoadScene(cutsceneSceneNames[currentCutsceneIndex], LoadSceneMode.Additive);
            MiscUtils.DoWithDelay(this, ()=> 
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(cutsceneSceneNames[currentCutsceneIndex]));
            
            }, 0.01f);
            currentCutsceneIndex++;
        }
        else
        {
            Debug.Log("All cutscenes played");
        }
    }
}
