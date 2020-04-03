using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EasyClass 
{
    public GameObject respawnE;
    public GameObject PlayerE;
    public void EasyMode()
    {
        Respawn();
    }
    public void Respawn()
    {
        PlayerE.transform.position = respawnE.transform.position;
    }
}
public class HardClass 
{
    public int dead = 0;
    public GameObject respawnH;
    public GameObject PlayerH;
    public void HardMode()
    {
        if (dead < 3)
        {
            Respawn();
            CountDeath();
        }
        else
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    public void Respawn()
    {
        PlayerH.transform.position = respawnH.transform.position;
    }
    public void CountDeath()
    {
        dead++;
    }

}
public class EventHandler
{
    public delegate void DeadEvent();
    public event DeadEvent onDeath;
    public void DieMethod()
    {
        onDeath();
    }
}
public class Die : MonoBehaviour
{
    EventHandler DeathEvent = new EventHandler();
    EasyClass easy = new EasyClass();
    HardClass hard = new HardClass();
    public GameObject respawn;
    public GameObject Player;
    public bool hardMode;
    void Start()
    {
        DeathEvent.onDeath += easy.EasyMode;
        easy.respawnE = respawn;
        easy.PlayerE = Player;
        hard.PlayerH = Player;
        hard.respawnH = respawn;
    }
    public void SwitchMode()
    {
        if (hardMode == false)
        {
            hardMode = true;
            DeathEvent.onDeath += hard.HardMode;
            DeathEvent.onDeath -= easy.EasyMode;
        }
        else
        {
            DeathEvent.onDeath += easy.EasyMode;
            DeathEvent.onDeath -= hard.HardMode;
            hardMode = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchMode();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            DeathEvent.DieMethod();
        }
    }

}
