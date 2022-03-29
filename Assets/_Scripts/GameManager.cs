
using UnityEngine;
using UnityEngine.UI;

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
    public int Score;
    public int bestScore;
    public int Lives;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtBestScore;
    [SerializeField] private Text txtLive;
    [SerializeField] private Text txtLevelShip;
    [SerializeField] private GameObject pnGameover;
    [SerializeField] private GameObject pnUIGamePause;
    [SerializeField] private GameObject pnUITutorial;
    public int levelShip;


    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else if (Ins)
        {
            Destroy(this);
        }
        levelShip = 1;
    }
    private void Start()
    {
        StartGamePlay();
        LoadScore();
        Score = 0;
        Lives = 3;
        gameState = GameState.Opening;
        AudioManager.Ins.StartCoroutine("PlayMusicBG");
        Invoke("DisablePanelUITutorial", 3.5f);
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
        if(Score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", Score);
        }
    }
    private void Update()
    {
        UpdateUIPlayer();
        UpgradeLevelShip();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    void UpdateUIPlayer()
    {
        txtLive.text = Lives.ToString();
        txtScore.text = Score.ToString();
        txtLevelShip.text = levelShip.ToString();
    }
    void SwitchGameState()
    {
        switch (gameState)
        {
            case GameState.Opening:
                pnGameover.SetActive(false);
                break;
            case GameState.Gameplay:
                pnGameover.SetActive(false);
                playerShip.SetActive(true);
                EnemySpawner.Ins.StarSpawnEnemy();
                break;
            case GameState.GameOver:
                EnemySpawner.Ins.StopSpawnEnemy();
                SetBestScore();
                pnGameover.SetActive(true);         
                break;
        }
    }
    void UpgradeLevelShip()
    {
        if (Score == 30)
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
        Score += _score;
    }
    public void SubtractionLive()
    {
        Lives -= 1;
    }
    public void HidePlayerShip()
    {
        playerShip.SetActive(false);
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
    public void ReloadNewGame()
    {
        SetGameManagerState(GameState.Opening);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pnUIGamePause.SetActive(true);
    }
    public void ResumeGame()
    {

        Time.timeScale = 1;
        pnUIGamePause.SetActive(false);
    }
    private void DisablePanelUITutorial()
    {
        pnUITutorial.SetActive(false);
    }
}
