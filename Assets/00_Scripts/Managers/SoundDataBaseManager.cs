using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoundDataBaseManager : ScriptableObject
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
            //중복검사
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
    Play = 20,
    Play2 = 30,
}

public enum SfxType
{
    None = 0,
    Jump1 = 10,
    Jump2 = 20,
    GetCoin = 30,
    Gem = 40,
    Water = 50,
    Boing = 60,
    Door = 70,
    Click = 80,
    Dead = 90,
}