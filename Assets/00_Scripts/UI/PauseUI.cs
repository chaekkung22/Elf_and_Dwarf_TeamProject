using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseUI : BaseUI
{
    protected override UIState UIState { get; } = UIState.Pause;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button resumeButton;

    protected override void Initialize()
    {
        base.Initialize();
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(OnClickRetryButton);

        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(OnClickMainButton);

        optionButton.onClick.RemoveAllListeners();
        optionButton.onClick.AddListener(OnClickOptionButton);

        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(OnClickResumeButton);
    }

    public override void SetUIActive(bool isActive)
    {
        UIManager.Instance.SetActivePauseButton(!isActive);
        base.SetUIActive(isActive);

        this.gameObject.SetActive(isActive);
    }

    private void OnClickRetryButton()
    {
        // TODO: 스테이지씬 다시 호출
        //SceneManager.LoadScene("StageScene")
        Debug.Log("Retry");
    }

    private void OnClickMainButton()
    {
        // TODO: 메인씬 호출
        // SceneManager.LoadScene("MainScene")
        Debug.Log("Goto Main");
    }

    private void OnClickOptionButton()
    {
        // TODO: Option UI 만들면 호출
        // UIManager.Instance.OpenUI(UIState.Option);
        Debug.Log("옵션UI Open");
    }

    private void OnClickResumeButton()
    {
        // TODO: 게임 일시정지 해제
        StageManager.Instance.ResumeGame();
        Debug.Log("Resume");
    }
}
