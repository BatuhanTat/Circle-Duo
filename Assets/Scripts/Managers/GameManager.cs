using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance { get; private set; }

    [SerializeField] private PlayerMovement player;

    [HideInInspector] public bool isGameOver = true;
    private int unlockedLevels; // Initially, only the first level is unlocked

    float levelLoadDelay = 0f;
    int levelCount = 0;
   
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
        LoadNextlevel();
        Debug.Log("OnWin");
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
        Debug.Log("Active Level Index: " + levelIndex);
        if (levelIndex == unlockedLevels)
        {
            Debug.Log("Level Index " + levelIndex + "  unlockedLevels: " + unlockedLevels);
            if (levelIndex == 1 || IsPreviousLevelCompleted(levelIndex))
            {
                unlockedLevels++;
                PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);

                PlayerPrefs.SetInt("Level_" + levelIndex, 1);
                PlayerPrefs.Save(); // Optional: Manually save PlayerPrefs
                LoadNextlevel();
            }
        }
    }

    public void LoadLevel(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            //Invoke(nameof(LoadDelayedScene), levelLoadDelay);
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
            StartCoroutine(LoadingDelay(0));
        }
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
        isGameOver = false;
        DOTween.KillAll();

        if (arg is string)
        {
            SceneManager.LoadSceneAsync((string)arg);
        }
        else if (arg is int)
        {
            SceneManager.LoadSceneAsync((int)arg);
        }
    }

    private bool IsPreviousLevelCompleted(int levelIndex)
    {
        if (levelIndex == 0) // First level has no previous level
        {
            return true;
        }

        return PlayerPrefs.GetInt("Level_" + (levelIndex - 1), 0) == 1;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
