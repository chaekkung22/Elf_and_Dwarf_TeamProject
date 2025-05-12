using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    protected override void Initialize()
    {
        DontDestroyOnLoad(gameObject);
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
        // 새 씬 비동기 로드
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName);
        while(!loadOp.isDone)
            yield return null;

        // 사용되지 않는 에셋 언로드
        yield return Resources.UnloadUnusedAssets();

        // 가비지 콜렉터 강제 실행
        System.GC.Collect();
    }
}
