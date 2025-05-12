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
    [SerializeField] private Button pausePanel;

    protected override void Initialize()
    {
        base.Initialize();
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));

        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));

        optionButton.onClick.RemoveAllListeners();
        optionButton.onClick.AddListener(OnClickOptionButton);

        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(StageManager.Instance.ResumeGame);

        pausePanel.onClick.AddListener(StageManager.Instance.ResumeGame);
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);

        this.gameObject.SetActive(isActive);
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
}
