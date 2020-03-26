using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AB : MonoBehaviour
{
    private string bundleURL = "https://drive.google.com/uc?export=download&id=1jXVeAFaypboPAJOzF5xvMo_qyREMOKJO";
    private int version = 0;
    [SerializeField] SpriteRenderer Srenderer;
    public void Awake()
    {
        StartCoroutine(Download());
    }
    IEnumerator Download()
    {
        var uwr = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return uwr.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
        if (bundle == null)
        {
            Sprite newSprite = bundle.LoadAsset<Sprite>("b0672bf5a53a46a3b453523ef4de09cc.png");
            yield return newSprite;
            Srenderer.sprite = newSprite;
        }
        else
            bundle.Unload(false);
    }
}