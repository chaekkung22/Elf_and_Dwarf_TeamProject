using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearUI : BaseUI
{
    protected override UIState UIState { get; } = UIState.StageClear;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private TextMeshProUGUI clearTitle;
    [SerializeField] private Sprite emptyStarImage;
    [SerializeField] private Sprite starImage;

    [SerializeField] private List<Image> starImages;

    [SerializeField] private TextMeshProUGUI clearTime;
    [SerializeField] private TextMeshProUGUI gold;


    protected override void Initialize()
    {
        base.Initialize();

        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));

        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);

        clearTitle.text = StageManager.Instance.IsClear ? "게임 클리어" : "게임 실패";

        for (int i = 0; i < 3; i++)
        {
            starImages[i].sprite = emptyStarImage;
        }

        int starCount = StageManager.Instance.StarCount;

        for (int i = 2; i > 2 - starCount; i--)
        {
            starImages[i].sprite = starImage;
        }

        TimeSpan time = TimeSpan.FromSeconds(StageManager.Instance.PlayTime);
        clearTime.text = $"시간 : {time.Minutes:00}:{time.Seconds:00}";
        gold.text = $"획득 골드: {StageManager.Instance.EarnGold}";

        this.gameObject.SetActive(isActive);
    }
}
