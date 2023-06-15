using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class AudioManager : MyMonoBehaviour
{
    #region Singleton Variables
    
    private static AudioManager instance;
    public static AudioManager Instance => instance;
    
    #endregion

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] backgroundMusic;

    public bool isPlayBGM;
    private int bgmIndex;
    
    protected override void Awake()
    {
        base.Awake();
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!isPlayBGM)
        {
            StopAllBGM();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "LevelBoss01" ||
                SceneManager.GetActiveScene().name == "LevelBoss02")
            {
                bgmIndex = 1;
            }
            else
            {
                bgmIndex = 0;
            }
            
            if (!backgroundMusic[bgmIndex].isPlaying)
            {
                PlayBGM(bgmIndex);
            }
        }
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < sfx.Length)
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.1f);
            sfx[sfxIndex].Play();
        }
    }

    public void StopSFX(int sfxIndex)
    {
        sfx[sfxIndex].Stop();
    }

    public void PlayBGM(int _bgmIndex)
    {
        this.bgmIndex = _bgmIndex;
        
        StopAllBGM();
        
        backgroundMusic[bgmIndex].Play();
    }

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, backgroundMusic.Length);
        PlayBGM(bgmIndex);
    }

    public void StopAllBGM()
    {
        for (int i = 0; i < backgroundMusic.Length; i++)
        {
            backgroundMusic[i].Stop();
        }
    }
}
