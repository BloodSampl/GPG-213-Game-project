using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public string[] cutsceneSceneNames = { "CutScene1", "CutScene2", "CutScene3", "CutScene4" };
    private int currentCutsceneIndex = 0;

    // This method is called on wave end
    public void OnWaveEnd()
    {
        if (currentCutsceneIndex < cutsceneSceneNames.Length)
        {
            SceneManager.LoadScene(cutsceneSceneNames[currentCutsceneIndex]);
            currentCutsceneIndex++;
        }
        else
        {
            Debug.Log("All cutscenes played");
        }
    }
}
