using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialCams;
    [SerializeField] GameObject[] tutorialGuidePages;

    [SerializeField] CanvasGroup blackOverlay;

    int currGuideIndex = -1;
    float defaultFadeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ShowGuide(0);
    }

    public void onClick_ShowNextGuide() 
    {
        ShowGuide(currGuideIndex + 1);
    }

    void ShowGuide(int guideIndex)
    {
        if (currGuideIndex == -1)
        {
            SetActiveGuideObjs(0);
            StartCoroutine(coroutine_FadeOut(blackOverlay, defaultFadeTime, null));
            currGuideIndex = 0;
        }
        else 
        {
            StartCoroutine(coroutine_FadeIn(blackOverlay, defaultFadeTime, ()=> 
            {
                SetActiveGuideObjs(guideIndex);
                StartCoroutine(coroutine_FadeOut(blackOverlay, defaultFadeTime, null));
                currGuideIndex = guideIndex;
            }));
        }
    }

    void SetActiveGuideObjs(int index)
    {
        for (int i = 0; i < tutorialCams.Length; i++)
        {
            if (i == index)
            {
                tutorialGuidePages[i].SetActive(true);
                tutorialCams[i].SetActive(true);
            }
            else
            {
                tutorialGuidePages[i].SetActive(false);
                tutorialCams[i].SetActive(false);
            }
        }
    }

    IEnumerator coroutine_FadeIn(CanvasGroup entity, float fadeTime, Action onComplete) 
    {
        entity.blocksRaycasts = true;
        entity.alpha = 0;

        while (entity.alpha < 1)
        {
            entity.alpha += (Time.deltaTime / fadeTime);
            yield return null;
        }

        entity.alpha = 1;
        yield return null;
        onComplete?.Invoke();
    }

    IEnumerator coroutine_FadeOut(CanvasGroup entity, float fadeTime, Action onComplete)
    {
        entity.blocksRaycasts = true;
        entity.alpha = 1;

        while (entity.alpha > 0)
        {
            entity.alpha -= (Time.deltaTime / fadeTime);
            yield return null;
        }

        entity.alpha = 0;
        entity.blocksRaycasts = false;
        yield return null;
        onComplete?.Invoke();
    }
}
