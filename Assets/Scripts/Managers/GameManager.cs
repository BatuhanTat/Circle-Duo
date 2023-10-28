using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;
    public enum State
    {
        Menu,
        Play,
        GameOver,
    }

    [SerializeField] private PlayerMovement player;
    public static GameManager instance { get; private set; }
    public State state;
    

    private int unlockedLevels; // Initially, only the first level is unlocked
    private float levelLoadDelay = 0f;
    private int levelCount = 0;
   
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        player.OnWin += Player_OnWin;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void Player_OnWin(object sender, System.EventArgs e)
    {
        CompleteLevel();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        // Minus booting scene.
        levelCount = SceneManager.sceneCountInBuildSettings - 1;
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1); // Load the unlockedLevels value from PlayerPrefs
    }

    public void CompleteLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log("Active Level Index: " + levelIndex);
        if (levelIndex == unlockedLevels)
        {
            //Debug.Log("Level Index " + levelIndex + "  unlockedLevels: " + unlockedLevels);
            if (levelIndex == 1 || IsPreviousLevelCompleted(levelIndex))
            {
                unlockedLevels++;
                PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);

                PlayerPrefs.SetInt("Level_" + levelIndex, 1);
                PlayerPrefs.Save(); // Optional: Manually save PlayerPrefs
            }
        }
        LoadNextlevel(); 
    }

    public void LoadLevel(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            StartCoroutine(LoadingDelay(sceneName));
        }
    }
    public void LoadNextlevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (levelIndex + 1 <= PlayerPrefs.GetInt("UnlockedLevels") && levelIndex + 1 <= levelCount)
        {
            StartCoroutine(LoadingDelay(levelIndex + 1));
        }
        else
        {
            // On completion of final level load menu, buildindex 0.
            LoadMenu(); 
        }
    }
    public void LoadMenu()
    {
        DOTween.KillAll();
        SceneManager.LoadSceneAsync(0);
        PlayerMovement.instance.Restart_OnComplete();
        SetState(State.Menu);

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetInt("LastPlayedLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save(); // Optional: Manually save PlayerPrefs
        PlayerMovement.instance.UpdatePosition();   
    }


    private IEnumerator LoadingDelay(object arg)
    {
        yield return new WaitForSeconds(levelLoadDelay);
        DOTween.KillAll();
        if (arg is string)
        {
            SceneManager.LoadSceneAsync((string)arg);
        }
        else if (arg is int)
        {     
            SceneManager.LoadSceneAsync((int)arg);
        }
        PlayerMovement.instance.RestartRotation();
    }

    private bool IsPreviousLevelCompleted(int levelIndex)
    {
        if (levelIndex == 0) // First level has no previous level
        {
            return true;
        }

        return PlayerPrefs.GetInt("Level_" + (levelIndex - 1), 0) == 1;
    }

    public void SetState(State state)
    {
        this.state = state;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
