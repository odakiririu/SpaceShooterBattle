using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Ins;
    private AudioSource audioSrc;
    private AudioSource audioSrcBackground;
    [SerializeField] private Slider sliderMusicBg;
    [SerializeField] private Slider sliderMusicVfx;
    private void Awake()
    {
        // add AudioSource in gameObject AudioCtrl
        audioSrc = gameObject.AddComponent<AudioSource>();
        audioSrcBackground = gameObject.AddComponent<AudioSource>();
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else if (Ins)
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        if(PlayerPrefs.HasKey("musicBg") && PlayerPrefs.HasKey("musicVFX"))
        {
            LoadSettingAudio();
        }
        else
        {
            PlayerPrefs.SetFloat("musicBg",1);
            PlayerPrefs.SetFloat("musicVFX", 1);
        }
        StartCoroutine("PlayMusicBG");
    }
    public void PlayMusic(string musicName) /// nay la VFX nhe
    {
        audioSrc.PlayOneShot((AudioClip)Resources.Load("_Sounds/" + musicName, typeof(AudioClip)));       
    }
    public IEnumerator PlayMusicBG() // 
    {
        if(audioSrcBackground.clip == null)
        {
            audioSrcBackground.clip = (AudioClip)Resources.Load("_Sounds/audioBackground", typeof(AudioClip));
        }          
        float length = audioSrcBackground.clip.length -2;
        while (true)
        {          
            audioSrcBackground.Play();
            yield return new WaitForSeconds(length);
        }
    }
    public void ChangeVolumeBg()
    {     
        audioSrcBackground.volume = sliderMusicBg.value;
        audioSrc.volume = sliderMusicVfx.value;
    }
    public void SaveSettingAudio()
    {
        PlayerPrefs.SetFloat("musicBg", sliderMusicBg.value);
        PlayerPrefs.SetFloat("musicVFX", sliderMusicVfx.value);
    }
    private void LoadSettingAudio()
    {
        audioSrcBackground.volume = PlayerPrefs.GetFloat("musicBg");
        audioSrc.volume = PlayerPrefs.GetFloat("musicVFX");
        sliderMusicBg.value = audioSrcBackground.volume;
        sliderMusicVfx.value = audioSrc.volume;
    }
}
