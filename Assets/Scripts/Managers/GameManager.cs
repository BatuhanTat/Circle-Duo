using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region Singleton class : GameManager
    public static GameManager instance { get; private set; }
    [SerializeField] private PlayerMovement player;
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
    }
    #endregion

    [HideInInspector] public bool isGameOver = false;

    private void Player_OnWin(object sender, System.EventArgs e)
    {
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex < SceneManager.sceneCount)
        {
            DOTween.KillAll();
            SceneManager.LoadSceneAsync(++currentLevelIndex);
        }
    }
}
