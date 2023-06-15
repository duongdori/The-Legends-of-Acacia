using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MyMonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLoaderUI();
        LoadSlider();
        
        loaderUI.SetActive(false);
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;

        float progress = 0;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if(progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    private void LoadLoaderUI()
    {
        if(loaderUI != null) return;
        loaderUI = GameObject.Find("LoaderUI");
        Debug.LogWarning(transform.name + " LoadLoaderUI", gameObject);
    }
    
    private void LoadSlider()
    {
        if(progressSlider != null) return;
        progressSlider = GetComponentInChildren<Slider>();
        Debug.LogWarning(transform.name + " LoadSlider", gameObject);
    }
}
