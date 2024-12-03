using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ObjectAr : Singleton<ObjectAr>
{
    public Material objectMaterial;
    private Color baseColor;
    bool havebaseColor = false;
    [SerializeField] Light customLight;
    [SerializeField] float firstLight = 1;
    [SerializeField] float waitTimeToAction;
    [SerializeField, Header("ROTATE")] bool isRotate;
    [SerializeField] Vector3 targetRotate;
    [SerializeField] float liveTime = 0.5f;
    [SerializeField] Ease ease;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource _as;
    [SerializeField] float curAlpha = 1;
    Quaternion firstRot;
    void Start()
    {
        baseColor = objectMaterial.GetColor("_BaseColor");
        firstRot = transform.rotation;
    }
    public void Inits()
    {
        transform.rotation = firstRot;
        customLight.intensity = firstLight;
        StartCoroutine(WaitAction());
    }
    IEnumerator WaitAction()
    {
        yield return new WaitForSeconds(waitTimeToAction);
        if (isRotate)
        {
            transform.DORotate(targetRotate, liveTime).SetEase(ease);
            yield return new WaitForSeconds(liveTime);
        }
        _as.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length + 1);

        while(curAlpha >= 0)
        {
            curAlpha -= 0.1f;
            SetTransparency(curAlpha);
            yield return new WaitForSeconds(0.1f);
        }

    }
    public void SetTransparency(float alphaValue)
    {
        customLight.intensity = alphaValue;
        //// Pastikan alphaValue antara 0 (transparan) dan 1 (opaque)
        //alphaValue = Mathf.Clamp01(alphaValue);
        //// Mengatur warna dengan nilai alpha baru
        //Color newColor = new Color(baseColor.r, baseColor.g, baseColor.b, alphaValue);
        //objectMaterial.SetColor("_BaseColor", newColor);
        Debug.Log(curAlpha);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
