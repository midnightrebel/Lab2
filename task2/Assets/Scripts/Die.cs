using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Die : MonoBehaviour
{

    public GameObject respawn;
    private GameObject Player;


    public UnityEvent DeadEvent;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            DeadEvent.Invoke();
        }
    }

    public void Respawn()
    {
        Player.transform.position = respawn.transform.position;
    }

}
