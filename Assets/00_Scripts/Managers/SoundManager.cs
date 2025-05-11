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

    public void PlayBgm(BgmType bgmType)
    {
        SoundDataBaseManager.BgmData bgmData = soundDataBaseManager.GetBgmData(bgmType);
        bgmAudioSource.clip = bgmData.clip;
            bgmAudioSource.Play();
    }

    public void PlaySfx(SfxType sfxType)
    {
        SoundDataBaseManager.SfxData sfxData = soundDataBaseManager.GetSfxData(sfxType);
            sfxAudioSource.PlayOneShot(sfxData.clip);
    }

    protected override void Initialize()
    {
        
    }
}
