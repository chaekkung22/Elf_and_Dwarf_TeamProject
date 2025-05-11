using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using static SoundManager;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudioSource;


    //GameManager
    [SerializeField] private DataBaseManager dataBaseManager;

    private void Start()
    {
        dataBaseManager.Init();
        PlayBgm(BgmType.Main);
    }

    public void PlayBgm(BgmType bgmType)
    {
        DataBaseManager.BgmData bgmData = dataBaseManager.GetBgmData(bgmType);
        bgmAudioSource.clip = bgmData.clip;
            bgmAudioSource.Play();
    }

    public void PlaySfx(SfxType sfxType)
    {
        DataBaseManager.SfxData sfxData = dataBaseManager.GetSfxData(sfxType);
            sfxAudioSource.PlayOneShot(sfxData.clip);
    }

    protected override void Initialize()
    {
        
    }
}
