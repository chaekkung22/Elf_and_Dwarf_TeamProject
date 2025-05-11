using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using static SoundManager;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{


    [SerializeField] private SfxData[] sfxDataArr = null;
    [SerializeField] private BgmData[] bgmDataArr = null;
    private Dictionary<BgmType, BgmData> bgmDataDic;
    private Dictionary<SfxType, SfxData> sfxDataDic;

    public void Init()
    {
        this.bgmDataDic = new Dictionary<BgmType, BgmData>();
        foreach (BgmData bgmData in this.bgmDataArr)
        {
            if (!this.bgmDataDic.ContainsKey(bgmData.bgmType))
                this.bgmDataDic.Add(bgmData.bgmType, bgmData);
            else
                Debug.LogWarning($"중복된 BgmType: {bgmData.bgmType}");
        }


        this.sfxDataDic = new Dictionary<SfxType, SfxData>();
        foreach (SfxData sfxData in this.sfxDataArr)
        {
            if (!this.sfxDataDic.ContainsKey(sfxData.sfxType))
                this.sfxDataDic.Add(sfxData.sfxType, sfxData);
            else
                Debug.LogWarning($"중복된 SfxType: {sfxData.sfxType}");
        }
    }


    public BgmData GetBgmData(BgmType type)
    {
        return this.bgmDataDic[type];
    }
    public SfxData GetSfxData(SfxType sfxType)
    {
        return this.sfxDataDic[sfxType];
    }
    [System.Serializable]
    public class SfxData
    {
        public SfxType sfxType;
        public AudioClip clip;
    }
    [System.Serializable]
    public class BgmData
    {
        public BgmType bgmType;
        public AudioClip clip;
    }
}
public enum BgmType
{
    None = 0,
    Main = 10,
}

public enum SfxType
{
    None = 0,
    jump1 = 10,
    jump2 = 20,
    getCoin = 30,
}

