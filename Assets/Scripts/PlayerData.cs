using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [HideInInspector]
    public static PlayerData player;

    [HideInInspector]
    public bool isGameStarted;
    [HideInInspector]
    public bool isGameOver;
    [HideInInspector]
    public bool isLevelPassed;
    [HideInInspector]
    public int levelCount = 1;
    [HideInInspector]
    public float totalHeight;

    private void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.StartListening("GameOver", StopGame);
        EventManager.StartListening("LevelUp", LevelUp);
        EventManager.StartListening("LevelPassed", PassLevel);
    }

    public void ResetLevel()
    {
        isGameOver = false;
        isLevelPassed = false;
    }

    public void ResetAll()
    {
        isGameOver = false;
        isLevelPassed = false;
        levelCount = 1;
    }

    public void StartGame()
    {
        player.isGameStarted = true;
    }

    public void PassLevel()
    {
        player.isLevelPassed = true;
    }

    public void StopGame()
    {
        player.isGameOver = true;
    }

    public void RestartGame()
    {
        player.ResetLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelUp()
    {
        ++player.levelCount;
        player.ResetLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
