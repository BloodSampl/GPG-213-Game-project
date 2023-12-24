using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public static ScenesController instance;

    private void Start()
    {
        instance = this;
    }

    public void LoadTutorialScene() 
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadGameScene() 
    {
        SceneManager.LoadScene(2);
    
    }

    /// <summary>
    /// 0 for cutscene1 and so on
    /// </summary>
    /// <param name="cutSceneIndex">Index of cutscene starting from 0</param>
    public void LoadCutscene(int cutSceneIndex) 
    {
        SceneManager.LoadScene(3 + cutSceneIndex);
    
    }
}
