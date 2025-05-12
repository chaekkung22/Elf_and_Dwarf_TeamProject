using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using static SoundManager;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudioSource;


    //GameManager
    [SerializeField] private SoundDataBaseManager soundDataBaseManager;

    private void Start()
    {
        soundDataBaseManager.Init();
        PlayBgm(BgmType.Main);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            VolumeUp();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
            VolumeDown();
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

    public void MuteAudio()
    {
        bgmAudioSource.mute = true;
        sfxAudioSource.mute = true;
    }
    public void PlayAudio()
    {
        bgmAudioSource.mute = false;
        sfxAudioSource.mute = false;
    }

    public void VolumeUp()
    {
        bgmAudioSource.volume += 0.2f;
        sfxAudioSource.volume += 0.2f;
    }
    public void VolumeDown()
    {
        bgmAudioSource.volume -= 0.2f;
        sfxAudioSource.volume -= 0.2f;
    }

    protected override void Initialize()
    {

    }
}
