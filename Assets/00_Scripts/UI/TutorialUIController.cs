using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIController : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> tutorialUIGroups;
    [SerializeField] private float fadeDuration = 0.5f;

    private bool[] isVisible;

    private void Awake()
    {
        isVisible = new bool[tutorialUIGroups.Count];
    }

    public void FadeIn(TutorialUIType type)
    {
        int index = (int)type;

        if (CheckVisible(index, true))
        {
            StartCoroutine(FadeCanvasGroup(tutorialUIGroups[index], 0, 1));
        }
    }

    public void FadeOut(TutorialUIType type)
    {
        int index = (int)type;

        if (CheckVisible(index, false))
        {
            StartCoroutine(FadeCanvasGroup(tutorialUIGroups[index], 1, 0));
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end)
    {
        float time = 0f;

        if (end > 0)
            canvasGroup.gameObject.SetActive(true);

        canvasGroup.alpha = start;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = end;

        if (end == 0)
            canvasGroup.gameObject.SetActive(false);
    }

    private bool CheckVisible(int index, bool shouldBeVisible)
    {
        if (isVisible[index] == shouldBeVisible)
            return false;

        isVisible[index] = shouldBeVisible;
        return true;
    }

}
