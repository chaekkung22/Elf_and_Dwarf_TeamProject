using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        retryButton.onClick.AddListener(OnClickRetryButton);

        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(OnClickMainButton);
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);

        StageManager stageManager = StageManager.Instance;

        // clearTitle.text = stageManager.isClear?"게임 클리어": "게임 실패";

        for (int i = 0; i < 3; i++)
        {
            starImages[i].sprite = emptyStarImage;
        }

        //int starCount = stageManager.starCount;

        // for (int i = 2; i > 2 - starCount; i--)
        // {
        //     starImages[i].sprite = starImage;
        // }

        // clearTime.text = $"시간 : {stageManager.playTime}";
        // gold.text = $"획득 골드: {stageManager.earnGold}";

        this.gameObject.SetActive(isActive);
    }

    private void OnClickRetryButton()
    {
        // TODO: 스테이지씬 다시 호출
        //SceneManager.LoadScene("StageScene")
    }

    private void OnClickMainButton()
    {
        // TODO: 메인씬 호출
        // SceneManager.LoadScene("MainScene")
    }

}
