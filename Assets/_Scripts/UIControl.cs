using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl Ins;
    [SerializeField] private GameObject pnUITutorial;
    [SerializeField] private GameObject pnGameover;
    [SerializeField] private GameObject pnUIGamePause;
    [SerializeField] private Text txtBestScore;
    [SerializeField] private Text txtLive;
    [SerializeField] private Text txtScoreInGame;
    [SerializeField] private Text txtScoreGameOver;
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
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisablePanelUITutorial", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIPlayer();
    }
    public void DisablePanelUITutorial()
    {
        pnUITutorial.SetActive(false);
    }
    private void UpdateUIPlayer()
    {
        txtLive.text = GameManager.Ins.lives.ToString();
        txtScoreInGame.text = GameManager.Ins.score.ToString();
        txtScoreGameOver.text = GameManager.Ins.score.ToString();
        txtBestScore.text = PlayerPrefs.GetInt("bestScore").ToString();
    }
    public void SetPanelGameOver(bool state)
    {
        pnGameover.SetActive(state);
    }
    public void SetPanelGamePause(bool state)
    {
        pnUIGamePause.SetActive(state);
    }
}
