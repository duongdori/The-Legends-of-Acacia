using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MyMonoBehaviour, ISaveManager
{

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private int indexScene;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSceneLoader();
        LoadContinueButton();
    }

    protected override void Start()
    {
        base.Start();

        // if (!SaveManager.Instance.HasSaveData())
        // {
        //     continueButton.SetActive(false);
        // }
    }

    public void NewGame()
    {
        Debug.Log("New Game");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SaveManager.Instance.DeleteSavedData();
        StartCoroutine(LevelManager.Instance.LoadSceneWithFadeEffect(1.5f, sceneIndex + 1));
    }
    
    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        StartCoroutine(LevelManager.Instance.LoadSceneWithFadeEffect(1.5f, indexScene));
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void LoadData(GameData data)
    {
        indexScene = data.sceneIndex;
    }

    public void SaveData(ref GameData data)
    {
        data.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    #region Load Components

    private void LoadSceneLoader()
    {
        if(sceneLoader != null) return;
        sceneLoader = FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>();
        Debug.LogWarning(transform.name + " LoadSceneLoader", gameObject);
    }
    
    private void LoadContinueButton()
    {
        if(continueButton != null) return;
        continueButton = GameObject.Find("CONTINUE");
        Debug.LogWarning(transform.name + " LoadContinueButton", gameObject);
    }

    #endregion
}
