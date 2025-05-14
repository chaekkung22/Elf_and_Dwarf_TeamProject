using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Image fadeImg;
    [SerializeField][Range(0f, 0.1f)] private float fadeSpeed;
    public bool GameStart { get; set; }

    protected override void Initialize()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode sceneMode) => { if (scene.name == "StageScene") GameStart = true; else GameStart = false; };
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadAndCleanup(sceneName));
    }

    private IEnumerator LoadAndCleanup(string sceneName)
    {
        do
        {
            Color color = fadeImg.color;
            color.a += Time.deltaTime;
            fadeImg.color = color;

            yield return null;
        } while (fadeImg.color.a < 1);

        // 새 씬 비동기 로드
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName);
        while (!loadOp.isDone)
            yield return null;

        // 사용되지 않는 에셋 언로드
        yield return Resources.UnloadUnusedAssets();

        // 가비지 콜렉터 강제 실행
        System.GC.Collect();

        do
        {
            Color color = fadeImg.color;
            color.a -= Time.deltaTime;
            fadeImg.color = color;

            yield return null;
        } while (fadeImg.color.a > 0);
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveDatas();
    }
}
