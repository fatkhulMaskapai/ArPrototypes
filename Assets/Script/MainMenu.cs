using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Singleton<MainMenu>
{
    [SerializeField] float TimeToShowHeader;
    [SerializeField] float headerAnimTime;
    [SerializeField] Transform headerTxt;
    [SerializeField] Ease ease;
    [SerializeField, Header("BUTTON")] Button bussBtn;
    [SerializeField] Button rollerBtn;
    [SerializeField] Button dollBtn;
    [SerializeField] Button backBtn;
    [SerializeField] float offsetX;
    [SerializeField] float animTimeButton;
    [SerializeField] RectTransform[] rects;
    [SerializeField] string notAvailableTxt = "This feature is not available yet";
    [SerializeField] string[] nextScenes;
    [SerializeField] GameObject[] panels;
    void Start()
    {
        headerTxt.localScale = Vector3.zero;
        Invoke("OnHeader", TimeToShowHeader);

        bussBtn.onClick.AddListener(() =>
        {
            EnablePanel(false, true);
            ObjectAr.Instance.Inits();
            //SceneManager.LoadScene(nextScenes[0]);
        });
        rollerBtn.onClick.AddListener(() =>
        {
            SSTools.ShowMessage(notAvailableTxt, SSTools.Position.top, SSTools.Time.twoSecond);
        });
        dollBtn.onClick.AddListener(() =>
        {
            SSTools.ShowMessage(notAvailableTxt, SSTools.Position.top, SSTools.Time.twoSecond);
        });
        backBtn.onClick.AddListener(() =>
        {
            EnablePanel();
            //SceneManager.LoadScene(backScene);
        });
        EnablePanel(true);
        StartCoroutine(AnimButton());
    }
    public void EnablePanel(bool p0 = true, bool p1 = false)
    {
        panels[0].SetActive(p0);
        panels[1].SetActive(p1);
    }
    IEnumerator AnimButton()
    {
        float no = offsetX;
        for (int i = 0; i < rects.Length; i++)
        {
            no *= -1;
            rects[i].anchoredPosition = new Vector2(no, rects[i].anchoredPosition.y);
        }
        for (int i = 0; i < rects.Length; i++)
        {
            rects[i].DOAnchorPosX(0, animTimeButton).SetEase(Ease.Linear);
            yield return new WaitForSeconds(animTimeButton);
        }
    }

    // Update is called once per frame
    void OnHeader()
    {
        headerTxt.DOScale(Vector3.one, TimeToShowHeader).SetEase(ease);
    }
    private void OnDestroy()
    {
        CancelInvoke();
    }
}
