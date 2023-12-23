using aitcHUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneLoad : MonoBehaviour
{
    public float loadTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        MiscUtils.DoWithDelay(this, ()=> { SceneManager.LoadScene("Main Scene"); }, loadTime);
    }

}
