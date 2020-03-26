
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Finish : Button
{
    public GameObject Player;
    public Text Win_text;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag  == "Player" && isActive)
        {
            Win_text.text = "Вы победили.";
            Destroy(other.gameObject);
        }
    }
}
