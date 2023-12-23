using aitcHUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneFinisher : MonoBehaviour
{
    public float animDuration;

    int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

      
        StartCoroutine(SetActiveScene());
    }

    private IEnumerator SetActiveScene()
    {
        yield return new WaitForSeconds(animDuration);

        SceneManager.UnloadSceneAsync(sceneIndex);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main Scene"));
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.01f);


        //SceneManager.UnloadSceneAsync(currentSceneIndex + 1);
        //SceneManager.LoadScene(currentSceneIndex + 2, LoadSceneMode.Additive);
        //yield return new WaitForFixedUpdate();
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextLevelName));
        //yield return new WaitForFixedUpdate();
    }
}
