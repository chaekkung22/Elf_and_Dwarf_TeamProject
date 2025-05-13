using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static SoundManager;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    // 오디오 믹서
    public AudioMixer audioMixer;

    // 슬라이더
    [SerializeField] private Slider BgmSlider;
    [SerializeField] private Slider SfxSlider;
    [SerializeField] private Toggle BgmMute;    // Mute를 On / Off할 Toggle
    [SerializeField] private Toggle SfxMute;	// Mute를 On / Off할 Toggle
    private bool isChangingManually = false;

    //GameManager
    [SerializeField] private SoundDataBaseManager soundDataBaseManager;

    protected override void Initialize()
    {
        soundDataBaseManager.Init();
        // PlayerPrefs에 Volume 값이 저장되어 있을 경우,
        LoadBgmVolume();
        LoadSfxVolume();
        // 슬라이더의 값이 변경될 때 AddListener를 통해 이벤트 구독
        BgmSlider.onValueChanged.AddListener(SetBgmVolume);
        SfxSlider.onValueChanged.AddListener(SetSfxVolume);
        // 토클의 값이 변경될 때 AddListener를 통해 이벤트 구독
        BgmMute.onValueChanged.AddListener(SetBgmMute);
        SfxMute.onValueChanged.AddListener(SetSfxMute);

        PlayBgm(BgmType.Main);
    }
    private void Start()
    {
        // audioMixer.SetFloat("audioMixer에 설정해놓은 Parameter", float 값)
        // audioMixer에 미리 설정해놓은 parameter 값을 변경하는 코드.
        // Mathf.Log10(BGMSlider.value) * 20 : 데시벨이 비선형적이기 때문에 해당 방식으로 값을 계산.
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }
    public void PlayBgm(BgmType bgmType)
    {
        bgmAudioSource.clip = soundDataBaseManager.GetBgmData(bgmType).clip;
        bgmAudioSource.Play();
    }

    public void PlaySfx(SfxType sfxType)
    {
        sfxAudioSource.PlayOneShot(soundDataBaseManager.GetSfxData(sfxType).clip);
    }

    public void SetBgmVolume(float value)
    {

        if (Mathf.Approximately(BgmSlider.value, 0f))
        {
            isChangingManually = true;
            BgmMute.isOn = true;
            isChangingManually = false;
        }
        else if (!isChangingManually)
        {
            isChangingManually = true;
            BgmMute.isOn = false;
            isChangingManually = false;
        }
        // 로그 연산 값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
        PlayerPrefs.SetFloat("BgmVolume", BgmSlider.value);
    }
    public void SetBgmMute(bool mute)
    {
        if (isChangingManually) return;

        isChangingManually = true;
        if (mute)
        {
            PlayerPrefs.SetFloat("BgmVolumeBeforeMute", BgmSlider.value);
            BgmSlider.value = 0;
        }
        else
        {
            float saved = PlayerPrefs.GetFloat("BgmVolumeBeforeMute", 0.5f);
            BgmSlider.value = saved == 0 ? 0.5f : saved;
        }
        PlayerPrefs.SetString("BgmMute", mute.ToString());
        isChangingManually = false;
    }

    public void SetSfxMute(bool mute)
    {
        if (isChangingManually) return;

        isChangingManually = true;
        if (mute)
        {
            PlayerPrefs.SetFloat("SfxVolumeBeforeMute", SfxSlider.value);
            SfxSlider.value = 0;
        }
        else
        {
            float saved = PlayerPrefs.GetFloat("SfxVolumeBeforeMute", 0.5f);
            SfxSlider.value = saved == 0 ? 0.5f : saved;
        }
        PlayerPrefs.SetString("SfxMute", mute.ToString());
        isChangingManually = false;
    }
    public void SetSfxVolume(float value)
    {

        if (Mathf.Approximately(SfxSlider.value, 0f))
        {
            isChangingManually = true;
            SfxMute.isOn = true;
            isChangingManually = false;
        }
        else if (!isChangingManually)
        {
            isChangingManually = true;
            SfxMute.isOn = false;
            isChangingManually = false;
        }
        // 로그 연산 값 전달
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", SfxSlider.value);
    }

    private void LoadBgmVolume()
    {
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            // Slider의 값을 저장해 놓은 값으로 변경.
            BgmSlider.value = PlayerPrefs.GetFloat("BgmVolume");

            audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
        }
        else
            BgmSlider.value = 0.5f;     // PlayerPrefs에 Volume이 없을 경우

        if (PlayerPrefs.HasKey("BgmMute"))
        {
            if (PlayerPrefs.GetString("BgmMute") == "true")
            {
                BgmMute.isOn = true;
            }
            else
                BgmMute.isOn = false;
        }
        else
            BgmMute.isOn = false;
    }
    private void LoadSfxVolume()
    {
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            // Slider의 값을 저장해 놓은 값으로 변경.
            SfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
            audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
        }
        else
            SfxSlider.value = 0.5f;     // PlayerPrefs에 Volume이 없을 경우

        if (PlayerPrefs.HasKey("SfxMute"))
        {
            if (PlayerPrefs.GetString("SfxMute") == "true")
            {
                SfxMute.isOn = true;
            }
            else
                SfxMute.isOn = false;
        }
        else
            SfxMute.isOn = false;
    }


}