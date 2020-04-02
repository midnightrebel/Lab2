using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Die : MonoBehaviour
{
    public delegate void DeadEvent();
    public event DeadEvent onDeath;
    
    public Text countDeath;
    public int dead = 0;
    public GameObject respawn;
    public GameObject Player;
    public bool hardMode;
    void Start()
    {
        onDeath += EasyMode;
    }
    public void Respawn()
    {
        Player.transform.position = respawn.transform.position;
    }
    public void SwitchMode()
    {
        if(hardMode == false)
        {
            hardMode = true;
            onDeath += HardMode;
            onDeath -= EasyMode;
        }
        else
        {
            onDeath += EasyMode;
            onDeath -= HardMode;
            hardMode = false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SwitchMode();
        }
    }
    public void CountDeath()
    {
        dead++;
        countDeath.text = "You died " + dead.ToString() + " times";
    }
    public void EasyMode()
    {
        Respawn();
        CountDeath();    
    }
    public void HardMode()
    {
        if(dead < 3)
        {
            Respawn();
            CountDeath();
        }
        else
        {
            Destroy(Player);
            SceneManager.LoadScene("Gameover");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            onDeath();
        }
    }

}
