using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameCtrl : MonoBehaviour
{
    public GameObject pnSettingGame;
    public GameObject pnMenuMain;
    public void ButtonPlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void ButtonSettingGame()
    {
        pnSettingGame.SetActive(true);
        pnMenuMain.SetActive(false);
    }
    public void ButtonContactGame()
    {
        Application.OpenURL("https://www.facebook.com/Ddkphutho");
    }
    public void ButtonQuitGame()
    {
        Application.Quit();
    }
    public void ButtonOkaySetting()
    {
        pnSettingGame.SetActive(false);
        pnMenuMain.SetActive(true);
        AudioManager.Ins.SaveSettingAudio();
    }
    public void ButtonCancelSetting()
    {
        pnSettingGame.SetActive(false);
        pnMenuMain.SetActive(true);       
    }
}
