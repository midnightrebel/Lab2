using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;
using System.IO;

public class Сoins : MonoBehaviour
{

    delegate void SetTextDelegate();
    SetTextDelegate CoinText;
    public Text coins;
    private int count = 0;
    public Text countText;
    public bool challengeMode;
    public void Save()
    {
        Stat stat = new Stat(count);
        XmlSerializer formatter = new XmlSerializer(typeof(Stat));
        using (FileStream fs = new FileStream("Assets/Saves/stat.xml", FileMode.Open))
        {
            formatter.Serialize(fs, stat);
            fs.Close();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            count++;
            SetText();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Finish")
        {
            if (challengeMode)
                ChallengeFinish();
            else
                SimpleFinish();
            CoinText();
        }
    }
    void SetText()
    {
        countText.text = "Coins: " + count.ToString();
    }
    public void SimpleFinish()
    {
        CoinText += Save;
    }
    public void ChallengeFinish()
    {
        if (count < 3) CoinText += LessCoins;
        else if (count == 2) CoinText += LastOneCoin;
    }
    public void LessCoins()
    {
        coins.text = "Bring " + (3 - count).ToString() + " more coins to finish";
    }
    public void LastOneCoin()
    {
        coins.text = "Bring " + (3 - count).ToString() + " more coin to finish";
    }
    public class Stat
    {
        public int Coins { get; set; }
        public Stat()
        { }

        public Stat(int coins)
        {
            Coins = coins;
        }
    }
}
