using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField] float liveTime;
    [SerializeField] float fadeTime = 1;
    [SerializeField] float waitTimeAfterFadeOut = 1;
    [SerializeField] string nextScene = "MainMenu";
    [SerializeField] CanvasGroup faderCanvasGroup;
    void Start()
    {
        faderCanvasGroup.alpha = 0;
        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        yield return StartCoroutine(Fade(1, fadeTime));
        yield return new WaitForSeconds(liveTime);
        yield return StartCoroutine(Fade(0, fadeTime));
        yield return new WaitForSeconds(waitTimeAfterFadeOut);
        SceneManager.LoadScene(nextScene);
    }
    public IEnumerator Fade(int finalAlpha, float fadeDurasi)
    {
        float finalAlp = finalAlpha;
        //isFading = true;
        faderCanvasGroup.blocksRaycasts = true;
        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlp) / fadeDurasi;
        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlp))
        {
            if (finalAlp != faderCanvasGroup.alpha)
            {
                faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlp, fadeSpeed * Time.deltaTime);
                yield return null;
            }
        }
        //isFading = false;
        faderCanvasGroup.blocksRaycasts = false;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
