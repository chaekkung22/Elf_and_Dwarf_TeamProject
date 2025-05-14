using UnityEngine;
using UnityEngine.UI;

public class OptionUI : BaseUI
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Toggle bgmMuteToggle;
    [SerializeField] private Toggle sfxMuteToggle;
    [SerializeField] private Button okButton;

    protected override UIState UIState => UIState.Option;
    private bool isChangingManually = false;

    protected override void Initialize()
    {
        base.Initialize();

        bgmSlider.onValueChanged.AddListener(OnBgmSliderChanged);
        sfxSlider.onValueChanged.AddListener(OnSfxSliderChanged);
        bgmMuteToggle.onValueChanged.AddListener(OnBgmMuteChanged);
        sfxMuteToggle.onValueChanged.AddListener(OnSfxMuteChanged);
        okButton.onClick.AddListener(() => UIManager.Instance.CloseUI());

        LoadSettings();
    }

    private void LoadSettings()
    {
        isChangingManually = true;

        bgmSlider.value = SoundManager.Instance.GetBgmVolume();
        sfxSlider.value = SoundManager.Instance.GetSfxVolume();
        bgmMuteToggle.isOn = SoundManager.Instance.IsBgmMuted();
        sfxMuteToggle.isOn = SoundManager.Instance.IsSfxMuted();

        isChangingManually = false;
    }

    private void OnBgmSliderChanged(float value)
    {
        if (isChangingManually) return;

        SoundManager.Instance.SetBgmVolume(value);
        isChangingManually = true;
        bgmMuteToggle.isOn = Mathf.Approximately(value, 0f);
        isChangingManually = false;
    }

    private void OnSfxSliderChanged(float value)
    {
        if (isChangingManually) return;

        SoundManager.Instance.SetSfxVolume(value);
        isChangingManually = true;
        sfxMuteToggle.isOn = Mathf.Approximately(value, 0f);
        isChangingManually = false;
    }

    private void OnBgmMuteChanged(bool isMuted)
    {
        if (isChangingManually) return;

        SoundManager.Instance.MuteBgm(isMuted);
        isChangingManually = true;
        bgmSlider.value = isMuted ? 0f : SoundManager.Instance.GetBgmVolume();
        isChangingManually = false;
    }

    private void OnSfxMuteChanged(bool isMuted)
    {
        if (isChangingManually) return;

        SoundManager.Instance.MuteSfx(isMuted);
        isChangingManually = true;
        sfxSlider.value = isMuted ? 0f : SoundManager.Instance.GetSfxVolume();
        isChangingManually = false;
    }
}
