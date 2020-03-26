using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SA : MonoBehaviour
{
    string folderPath;
    string[] filePaths;


    public void Awake()
    {
        ImageLoader();
    }

    public void ImageLoader()
    {

        folderPath = Path.Combine(Application.streamingAssetsPath, "/Sprites");
        filePaths = Directory.GetFiles(folderPath, "b0672bf5a53a46a3b453523ef4de09cc.png");
        byte[] pngBytes = System.IO.File.ReadAllBytes(folderPath);
      
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
      
        Sprite fromTex = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
   
        GetComponent<SpriteRenderer>().sprite = fromTex;
    }
}

