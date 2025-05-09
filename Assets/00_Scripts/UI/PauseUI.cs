using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseUI : BaseUI
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button optionButton;

    protected override void Initialize()
    {
        base.Initialize();
    }

    public override void SetUIActive(bool isActive)
    {


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

    private void OnClickOptionButton()
    {
        // TODO: Option UI 만들면 호출
        // UIManager.Instance.OpenUI(UIState.Option);
    }

    private void OnClickResumeButton()
    {
        // TODO: 게임 일시정지 해제
        // StageManager.Instance.PauseGame();
    }
}
