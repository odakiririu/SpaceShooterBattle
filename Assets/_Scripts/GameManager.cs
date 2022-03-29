
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;
    public enum GameState
    {
        Opening,
        Gameplay,
        GamePause,
        GameOver
    }
    public GameState gameState;

    // khai bao bien de quan li
    public GameObject playerShip;
    public int score;
    public int bestScore;
    public int lives;
    public int levelShip;


    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else if (Ins)
        {
            Destroy(this);
        }
       
    }
    private void Start()
    {
        playerShip = GameObject.Find("/Player");
        StartGamePlay();
        LoadScore();
        gameState = GameState.Opening;
        AudioManager.Ins.StartCoroutine("PlayMusicBG");       
    }
    void LoadScore()
    {
        if (!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", 0);
        }
        bestScore = PlayerPrefs.GetInt("bestScore");
    }
    void SetBestScore()
    {
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
    private void Update()
    {
        UpgradeLevelShip();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void SwitchGameState()
    {
        switch (gameState)
        {
            case GameState.Opening:
                UIControl.Ins.SetPanelGameOver(false);
                break;
            case GameState.Gameplay:
                score = 0;
                lives = 3;
                PlayerIns.Ins.InitPlayer();
                UIControl.Ins.SetPanelGameOver(false);
              //  playerShip.SetActive(true);
                EnemySpawner.Ins.StarSpawnEnemy();
                break;
            case GameState.GameOver:
                EnemySpawner.Ins.StopSpawnEnemy();
                SetBestScore();
                UIControl.Ins.SetPanelGameOver(true);
                break;
        }
    }
    void UpgradeLevelShip()
    {
        if (score == 30)
        {
            levelShip = 2;
        }
    }
    public void SetGameManagerState(GameState state)
    {
        gameState = state;
        SwitchGameState();
    }
    public void IncreaseScore(int _score)
    {
        score += _score;
    }
    public void SubtractionLive()
    {
        lives -= 1;
    }
    public void DestroyEnemyShip(GameObject gameObject)
    {
        Destroy(gameObject);

        IncreaseScore(10);
    }
    public void StartGamePlay()
    {
        SetGameManagerState(GameState.Gameplay);
    }
    public void ButtonRestart()
    {
        SetGameManagerState(GameState.Gameplay);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        UIControl.Ins.SetPanelGamePause(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        UIControl.Ins.SetPanelGamePause(false);
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
    public void ButtonGoHome()
    {
        SceneManager.LoadScene("GameStart");
    }
}
