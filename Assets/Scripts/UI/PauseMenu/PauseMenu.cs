using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MyMonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPauseMenu();
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ContinueGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        GameIsPause = true;
        Time.timeScale = 0f;
    }

    public void LoadOptions()
    {
        Debug.Log("Loading Options");
    }
    
    public void ExitGame()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        Debug.Log("Exit Game");
        Application.Quit();
    }

    private void LoadPauseMenu()
    {
        if(pauseMenuUI != null) return;
        pauseMenuUI = transform.Find("PauseMenu").gameObject;
        Debug.LogWarning(transform.name + " LoadPauseMenu", gameObject);
    }
}
