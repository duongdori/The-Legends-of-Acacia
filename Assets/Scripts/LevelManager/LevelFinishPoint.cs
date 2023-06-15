using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            SaveManager.Instance.SaveGame();
            
            StartCoroutine(
                LevelManager.Instance.LoadSceneWithFadeEffect(1.5f, 
                    LevelManager.Instance.GetCurrentSceneIndex() + 1));
        }
    }
}
