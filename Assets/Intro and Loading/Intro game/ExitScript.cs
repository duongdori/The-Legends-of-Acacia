using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public string nextSceneName;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
