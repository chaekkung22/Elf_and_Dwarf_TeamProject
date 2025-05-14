using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    public AudioMixer audioMixer;
    [SerializeField] private SoundDataBaseManager soundDataBaseManager;

    protected override void Initialize()
    {
        soundDataBaseManager.Init();
    }
    private void Start()
    {
        LoadVolumes();
        PlayBgm(BgmType.Main);
    }
    private void LoadVolumes()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0.5f);
        float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0.5f);

        bgmVolume = Mathf.Max(bgmVolume, 0.0001f);
        sfxVolume = Mathf.Max(sfxVolume, 0.0001f);

        audioMixer.SetFloat("BGM", Mathf.Log10(bgmVolume) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
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
        value = Mathf.Max(value, 0.0001f);
        audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BgmVolume", value);
    }

    public void SetSfxVolume(float value)
    {
        value = Mathf.Max(value, 0.0001f);
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    public void MuteBgm(bool mute)
    {
        if (mute)
        {
            float saved = PlayerPrefs.GetFloat("BgmVolume", 0.5f);
            PlayerPrefs.SetFloat("BgmVolumeBeforeMute", saved);
            SetBgmVolume(0.0001f);
        }
        else
        {
            float restored = PlayerPrefs.GetFloat("BgmVolumeBeforeMute", 0.5f);
            SetBgmVolume(restored);
        }

        PlayerPrefs.SetInt("BgmMuted", mute ? 1 : 0);
    }

    public void MuteSfx(bool mute)
    {
        if (mute)
        {
            float saved = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
            PlayerPrefs.SetFloat("SfxVolumeBeforeMute", saved);
            SetSfxVolume(0.0001f);
        }
        else
        {
            float restored = PlayerPrefs.GetFloat("SfxVolumeBeforeMute", 0.5f);
            SetSfxVolume(restored);
        }

        PlayerPrefs.SetInt("SfxMuted", mute ? 1 : 0);
    }

    public bool IsBgmMuted() => PlayerPrefs.GetInt("BgmMuted", 0) == 1;
    public bool IsSfxMuted() => PlayerPrefs.GetInt("SfxMuted", 0) == 1;
    public float GetBgmVolume() => PlayerPrefs.GetFloat("BgmVolume", 0.5f);
    public float GetSfxVolume() => PlayerPrefs.GetFloat("SfxVolume", 0.5f);
}
