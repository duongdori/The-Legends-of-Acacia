using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MyMonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    [SerializeField] private Animator anim;
    public int startSceneIndex = 3;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }

    protected override void Awake()
    {
        base.Awake();
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void FadeIn() => anim.SetTrigger("FadeIn");
    public void FadeOut() => anim.SetTrigger("FadeOut");

    public int GetCurrentSceneIndex() => SceneManager.GetActiveScene().buildIndex;

    public IEnumerator LoadSceneWithFadeEffect(float delay, int sceneIndex)
    {
        FadeOut();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
    
    public IEnumerator LoadStartScene(float delay, int sceneIndex)
    {
        yield return new WaitForSeconds(2f);
        FadeOut();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    private void LoadAnimator()
    {
        if(anim != null) return;
        anim = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + " LoadAnimator", gameObject);
    }
}
